using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;

public partial class Plugin
{
    void LogMessage(string message) => Logger.LogInformation($" > [HealthPack] {message}");
    void Debug(string message) { if (Config.Debug) Logger.LogDebug($" > [HealthPack DEBUG] {message}"); }

    void ChatMessage(CCSPlayerController player, string message)
    {
        if (Config.Chat.Enabled)
            player.PrintToChat(Config.Chat.Prefix + message);
    }
    void ChatMessageAll(string message)
    {
        if (Config.Chat.Enabled)
            Server.PrintToChatAll(Config.Chat.Prefix + message);
    }

    Random random = new Random();
    bool RandomPercent(int percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0-100");

        return random.Next(100) < percentage;
    }

    void ClearPacks()
    {
        PackCount = 0;

        foreach (var pack in DroppedPacks)
        {
            if (pack.Key != null && pack.Key.IsValid)
                pack.Key.Remove();

            if (pack.Value.Trigger != null && pack.Value.Trigger.IsValid)
                pack.Value.Trigger.Remove();

            pack.Value.Timer?.Kill();
        }

        DroppedPacks.Clear();
    }
}