using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace HealthPacks
{
    public partial class HealthPacks
    {
        public string Prefix = $"{ChatColors.LightRed}[HealthPack]";

        public readonly Dictionary<string, CBaseEntity> groupedEntities = new();
        public readonly Dictionary<string, Timer> DropTimers = new();

        public int maxPackCount = 64;
        public int PackCount = 0;
        public int Tickrate { get; set; } = 0;

        public void LogMessage(string message) => Logger.LogInformation($" > [HealthPack] {message}");
        public void Debug(string message) { if (Config.Debug) Logger.LogDebug($" > [HealthPack DEBUG] {message}"); }

        public void ChatMessage(CCSPlayerController client, string message)
        {
            if (Config.Chat.Enabled)
            client.PrintToChat(Colors($" {Prefix} {ChatColors.Default}{message}"));
        }
        public void ChatMessageAll(string message)
        {
            if (Config.Chat.Enabled)
                Server.PrintToChatAll(Colors($" {Prefix} {message}"));
        }

        public void PlaySound(CCSPlayerController client, string sound)
        {
            if (Config.Sounds.Enabled)
            client.ExecuteClientCommand($"play {sound}");
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

        public string Colors(string message)
        {
            string pattern = @"\{(\w+)\}";
            return Regex.Replace(message, pattern, match =>
            {
                string colorName = match.Groups[1].Value;
                if (colorMap.TryGetValue(colorName, out char colorValue))
                    return colorValue.ToString();

                return match.Value;
            });
        }
        public readonly Dictionary<string, char> colorMap = new Dictionary<string, char>
        {
            { "default", ChatColors.Default },
            { "white", ChatColors.White },
            { "darkred", ChatColors.DarkRed },
            { "green", ChatColors.Green },
            { "lightyellow", ChatColors.LightYellow },
            { "lightblue", ChatColors.LightBlue },
            { "olive", ChatColors.Olive },
            { "lime", ChatColors.Lime },
            { "red", ChatColors.Red },
            { "lightpurple", ChatColors.LightPurple },
            { "purple", ChatColors.Purple },
            { "grey", ChatColors.Grey },
            { "yellow", ChatColors.Yellow },
            { "gold", ChatColors.Gold },
            { "silver", ChatColors.Silver },
            { "blue", ChatColors.Blue },
            { "darkblue", ChatColors.DarkBlue },
            { "bluegrey", ChatColors.BlueGrey },
            { "magenta", ChatColors.Magenta },
            { "lightred", ChatColors.LightRed },
            { "orange", ChatColors.Orange }
        };
    }
}
