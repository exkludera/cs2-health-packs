using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace HealthPacks
{
    public partial class HealthPacks
    {
        public void CreatePack(CCSPlayerController client)
        {
            AddTimer(0.05f + Config.Settings.DropDelay, () =>
            {
                var deathOrigin = client.Pawn.Value!.CBodyComponent!.SceneNode!.AbsOrigin;
                deathOrigin.Z = deathOrigin.Z + Config.Entity.SpawnHeight;

                var packID = RandomString(12);

                CDynamicProp pack = Utilities.CreateEntityByName<CDynamicProp>("prop_dynamic_override")!;

                pack.Globalname = packID;
                pack.SetModel(Config.Entity.Model);
                pack.DispatchSpawn();
                pack.Teleport(deathOrigin);

                groupedEntities[packID] = pack;

                AddTimer(Config.Entity.DeleteTimer, () => RemoveDroppedPack(packID));

                if (Config.Chat.DropAnnounce)
                    ChatMessageAll(Localizer["pack_dropped", client.PlayerName, Config.Settings.HealAmount]);

                PackCount--;
                Debug($"CreatePack: {packID}");
            });
        }

        public void PackTouched(CCSPlayerController client, string packID)
        {
            var clientValue = client.PlayerPawn.Value!;
            if (clientValue.Health < Config.Settings.MaxHealth)
            {
                RemoveDroppedPack(packID);

                int newHealth = Math.Min(clientValue.Health + Config.Settings.HealAmount, Config.Settings.MaxHealth);
                clientValue.Health = newHealth;
                Utilities.SetStateChanged(clientValue, "CBaseEntity", "m_iHealth");

                PlaySound(client, Config.Sounds.PickupSound);

                if (Config.Chat.DropAnnounce)
                    ChatMessage(client, Localizer["pack_used", Config.Settings.HealAmount]);

                Debug("Pack Used");
            }
            else
            {
                if (Config.Entity.DeleteIfFullHealth)
                {
                    RemoveDroppedPack(packID);
                    PlaySound(client, Config.Sounds.PickupFailSound);
                    ChatMessage(client, Localizer["pack_destroyed"]);
                    Debug("Pack Destroyed");
                }
                else
                {
                    PlaySound(client, Config.Sounds.PickupSound);
                    ChatMessage(client, Localizer["pack_ignored"]);
                    Debug("Pack Ignored");
                }
            }
            Debug($"PackTouched: {packID}");
        }

        public void RemoveDroppedPack(string packID)
        {
            if (groupedEntities.TryGetValue(packID, out var pack))
            {
                if (pack != null && pack.IsValid)
                    pack.Remove();

                groupedEntities.Remove(packID);
            }

            if (DropTimers.ContainsKey(packID))
            {
                DropTimers[packID].Dispose();
                DropTimers.Remove(packID);
            }

            PackCount--;
            Debug($"RemoveDroppedPack: {packID}");
        }
    }
}
