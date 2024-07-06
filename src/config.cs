using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace HealthPacks
{
    public class ConfigSettings : BasePluginConfig
    {
        public class SettingsClass
        {
            public bool AlwaysDrop { get; set; } = false;
            public int DropPercentage { get; set; } = 50;
            public float DropDelay { get; set; } = 0.1f;
            public int HealAmount { get; set; } = 40;
            public int MaxHealth { get; set; } = 100;
            public float PickupDistance { get; set; } = 32f;
        }
        [JsonPropertyName("Settings")] public SettingsClass Settings { get; set; } = new SettingsClass();

        public class EntityClass
        {
            public string Model { get; set; } = "models/chicken/chicken_roasted.vmdl";
            public float DeleteTimer { get; set; } = 10;
            public bool DeleteIfFullHealth { get; set; } = true;
            public int SpawnHeight { get; set; } = 10;
            public int MaxCount { get; set; } = 64;
        }
        [JsonPropertyName("Entity")] public EntityClass Entity { get; set; } = new EntityClass();

        public class ChatClass
        {
            public bool Enabled { get; set; } = true;
            public string Prefix { get; set; } = "{lightred}[HealthPack]";
            public bool DropAnnounce { get; set; } = true;
            public bool PickupAnnounce { get; set; } = true;
        }
        [JsonPropertyName("Chat")] public ChatClass Chat { get; set; } = new ChatClass();

        public class SoundsClass
        {
            public bool Enabled { get; set; } = true;
            public string PickupSound { get; set; } = "sounds/buttons/blip1.vsnd";
            public string PickupFailSound { get; set; } = "sounds/buttons/button8.vsnd";
        }
        [JsonPropertyName("Sounds")] public SoundsClass Sounds { get; set; } = new SoundsClass();

        public bool Debug { get; set; } = false;
    }
}
