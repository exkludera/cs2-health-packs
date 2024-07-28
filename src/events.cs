using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

namespace HealthPacks
{
    public partial class HealthPacks
    {
        public HookResult RoundStart(EventRoundStart @event, GameEventInfo info)
        {
            PackCount = 0;
            groupedEntities.Clear();
            DropTimers.Clear();
            return HookResult.Continue;
        }

        public HookResult PlayerDeath(EventPlayerDeath @event, GameEventInfo info)
        {
            if (PackCount >= maxPackCount)
            {
                LogMessage($"Too many entities spawned, max is {maxPackCount}");
                return HookResult.Continue;
            }

            if (Config.Settings.AlwaysDrop || RandomPercent(Config.Settings.DropPercentage))
                CreatePack(@event.Userid!);

            return HookResult.Continue;
        }

        public void TickCalculatePack()
        {
            Tickrate++;

            if (Tickrate != 64)
                return;

            Tickrate = 0;

            Utilities.GetPlayers().ForEach(player =>
            {
                if (!player.PawnIsAlive || player.IsBot)
                    return;

                foreach (var kvp in groupedEntities)
                {
                    string key = kvp.Key;
                    CBaseEntity entity = kvp.Value;

                    Vector position = entity.AbsOrigin!;

                    float distance = DistanceTo(position, player.Pawn?.Value!.CBodyComponent?.SceneNode!.AbsOrigin!);

                    if (distance < Config.Settings.PickupDistance)
                        PackTouched(player, kvp.Key);
                }
            });
        }

        public void ServerPrecacheResources(ResourceManifest manifest)
        {
            manifest.AddResource(Config.Entity.Model);
        }
    }
}
