using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace HealthPacks
{
    public partial class HealthPacks
    {
        public readonly Dictionary<string, CBaseEntity> groupedEntities = new();
        public readonly Dictionary<string, Timer> DropTimers = new();

        public int maxPackCount = 64;
        public int PackCount = 0;
        public int Tickrate { get; set; } = 0;

        public void LogMessage(string message) => Logger.LogInformation($" > [HealthPack] {message}");
        public void Debug(string message) { if (Config.Debug) Logger.LogDebug($" > [HealthPack DEBUG] {message}"); }

        public void ChatMessage(CCSPlayerController player, string message)
        {
            if (Config.Chat.Enabled)
            player.PrintToChat(Config.Chat.Prefix + message);
        }
        public void ChatMessageAll(string message)
        {
            if (Config.Chat.Enabled)
            Server.PrintToChatAll(Config.Chat.Prefix + message);
        }

        public void PlaySound(CCSPlayerController player, string sound)
        {
            if (Config.Sounds.Enabled)
            player.ExecuteClientCommand($"play {sound}");
        }

        private static float DistanceTo(Vector a, Vector b)
        {
            return (float)
            Math.Sqrt(
                Math.Pow(a.X - b.X, 2) +
                Math.Pow(a.Y - b.Y, 2) +
                Math.Pow(a.Z - b.Z, 2)
            );
        }

        public string RandomString(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            var result = new char[length];
            for (int i = 0; i < length; i++)
                result[i] = chars[random.Next(chars.Length)];

            return new string(result);
        }

        public Random random = new Random();
        public bool RandomPercent(int percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0-100");

            return random.Next(100) < percentage;
        }
    }
}
