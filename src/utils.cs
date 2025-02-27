using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    void PlaySound(CCSPlayerController player, string sound, float volume = 1.0f, float pitch = 1.0f)
    {
        if (Config.Sounds.Enabled)
        {
            if (Config.Sounds.SoundEvents)
            {
                var parameters = new Dictionary<string, float>
                {
                    { "volume", volume },
                    { "pitch", pitch }
                };

                player.EmitSound(sound, parameters);
            }
            else player.ExecuteClientCommand($"play {sound}");
        }
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