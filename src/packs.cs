using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities.Constants;
using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Utils;
using Timer = CounterStrikeSharp.API.Modules.Timers.Timer;

public partial class Plugin
{
    Dictionary<CBaseProp, (Timer Timer, CEntityInstance Trigger)> DroppedPacks = new();

    int maxPackCount = 64;
    int PackCount = 0;

    void CreatePack(CCSPlayerController player)
    {
        AddTimer(0.0f + Config.Settings.DropDelay, () =>
        {
            var pawn = player.PlayerPawn.Value;
            if (pawn == null) return;

            Vector deathOrigin = new(pawn.AbsOrigin!.X, pawn.AbsOrigin.Y, pawn.AbsOrigin.Z + Config.Entity.SpawnHeight);

            var pack = Utilities.CreateEntityByName<CPhysicsPropOverride>("prop_physics_override")!;

            pack.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags &= ~(uint)(1 << 2);
            pack.EnableUseOutput = false;

            pack.Collision.SolidType = SolidType_t.SOLID_NONE;
            pack.Collision.SolidFlags = 0;

            pack.SetModel(Config.Entity.Model);
            pack.DispatchSpawn();

            pack.Collision.CollisionGroup = (byte)CollisionGroup.COLLISION_GROUP_DISSOLVING;
            pack.Collision.CollisionAttribute.CollisionGroup = (byte)CollisionGroup.COLLISION_GROUP_DISSOLVING;
            Utilities.SetStateChanged(pack, "CCollisionProperty", "m_CollisionGroup");
            Utilities.SetStateChanged(pack, "VPhysicsCollisionAttribute_t", "m_nCollisionGroup");

            pack.Teleport(deathOrigin, pawn.AbsRotation, new(0, 0, Config.Entity.SpawnVelocity));

            var trigger = CreateTrigger(pack);
            var timer = AddTimer(Config.Entity.DeleteTimer, () => RemoveDroppedPack(pack), TimerFlags.STOP_ON_MAPCHANGE);

            DroppedPacks.Add(pack, (timer, trigger));

            if (Config.Chat.DropAnnounce)
                ChatMessageAll(Localizer["pack_dropped", player.PlayerName, Config.Settings.HealAmount]);

            PackCount--;
            Debug($"Created Pack");
        });
    }

    CTriggerMultiple CreateTrigger(CBaseProp pack)
    {
        var trigger = Utilities.CreateEntityByName<CTriggerMultiple>("trigger_multiple")!;

        trigger.Entity!.Name = pack.Entity!.Name + "_trigger";
        trigger.Spawnflags = 1;
        trigger.CBodyComponent!.SceneNode!.Owner!.Entity!.Flags &= ~(uint)(1 << 2);
        trigger.Collision.SolidType = SolidType_t.SOLID_VPHYSICS;
        trigger.Collision.SolidFlags = 0;
        trigger.Collision.CollisionGroup = 14;

        trigger.SetModel(pack.CBodyComponent!.SceneNode!.GetSkeletonInstance().ModelState.ModelName);
        trigger.DispatchSpawn();
        trigger.Teleport(pack.AbsOrigin, pack.AbsRotation);
        trigger.AcceptInput("FollowEntity", pack, trigger, "!activator");
        trigger.AcceptInput("Enable");

        return trigger;
    }

    public void PackTouched(CCSPlayerController player, CBaseProp pack)
    {
        var pawn = player.PlayerPawn.Value;
        if (pawn == null) return;

        if (pawn.Health < Config.Settings.MaxHealth)
        {
            RemoveDroppedPack(pack);

            int newHealth = Math.Min(pawn.Health + Config.Settings.HealAmount, Config.Settings.MaxHealth);
            pawn.Health = newHealth;
            Utilities.SetStateChanged(pawn, "CBaseEntity", "m_iHealth");

            PlaySound(player, Config.Sounds.PickupSound);

            if (Config.Chat.DropAnnounce)
                ChatMessage(player, Localizer["pack_used", Config.Settings.HealAmount]);

            Debug("Pack Used");
        }
        else
        {
            if (Config.Entity.DeleteIfFullHealth)
            {
                RemoveDroppedPack(pack);
                PlaySound(player, Config.Sounds.PickupFailSound);
                ChatMessage(player, Localizer["pack_destroyed"]);
                Debug("Pack Destroyed");
            }
            else
            {
                PlaySound(player, Config.Sounds.PickupSound);
                ChatMessage(player, Localizer["pack_ignored"]);
                Debug("Pack Ignored");
            }
        }
        Debug($"Touched Pack");
    }

    public void RemoveDroppedPack(CBaseProp pack)
    {
        if (DroppedPacks.TryGetValue(pack, out var data))
        {
            DroppedPacks.Remove(pack);

            var (timer, trigger) = data;

            if (pack != null && pack.IsValid)
                pack.Remove();

            if (trigger != null && trigger.IsValid)
                trigger.Remove();

            timer?.Kill();

            PackCount--;
            Debug("Removed Dropped Pack");
        }
        else Debug("Failed to Remove Dropped Pack");
    }
}