using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;

public partial class Plugin
{
    void ServerPrecacheResources(ResourceManifest manifest)
    {
        string model = Config.Entity.Model;
        if (!string.IsNullOrEmpty(model))
            manifest.AddResource(model);

        string soundevent = Config.Sounds.SoundEvent;
        if (!string.IsNullOrEmpty(soundevent))
            manifest.AddResource(soundevent);
    }

    HookResult EventRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        ClearPacks();

        return HookResult.Continue;
    }

    HookResult EventPlayerDeath(EventPlayerDeath @event, GameEventInfo info)
    {
        var player = @event.Userid;
        if (player == null) return HookResult.Continue;

        if (PackCount >= maxPackCount)
        {
            LogMessage($"Too many entities spawned, max is {maxPackCount}");
            return HookResult.Continue;
        }

        if (Config.Settings.AlwaysDrop || RandomPercent(Config.Settings.DropPercentage))
            CreatePack(player);

        return HookResult.Continue;
    }

    HookResult trigger_multiple(CEntityIOOutput output, string name, CEntityInstance activator, CEntityInstance caller, CVariant value, float delay)
    {
        if (activator.DesignerName != "player")
            return HookResult.Continue;

        var pawn = activator.As<CCSPlayerPawn>();
        if (pawn == null || !pawn.IsValid)
            return HookResult.Continue;

        var player = pawn.OriginalController?.Value?.As<CCSPlayerController>();
        if (player == null || player.IsBot)
            return HookResult.Continue;

        var pack = DroppedPacks.FirstOrDefault(x => x.Value.Trigger == caller).Key;

        if (pack != null)
            PackTouched(player, pack);

        return HookResult.Continue;
    }
}