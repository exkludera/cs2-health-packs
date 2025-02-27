using CounterStrikeSharp.API.Core;

public class Config : BasePluginConfig
{
    public class Config_Settings
    {
        public bool AlwaysDrop { get; set; } = false;
        public int DropPercentage { get; set; } = 50;
        public float DropDelay { get; set; } = 0f;
        public int HealAmount { get; set; } = 40;
        public int MaxHealth { get; set; } = 100;
    }
    public Config_Settings Settings { get; set; } = new Config_Settings();

    public class Config_Entity
    {
        public string Model { get; set; } = "models/therazu/props/healthpack/healthpack.vmdl";
        public float DeleteTimer { get; set; } = 10;
        public bool DeleteIfFullHealth { get; set; } = false;
        public float SpawnHeight { get; set; } = 32;
        public float SpawnVelocity { get; set; } = 250;
        public int MaxCount { get; set; } = 64;
    }
    public Config_Entity Entity { get; set; } = new Config_Entity();

    public class Config_Chat
    {
        public bool Enabled { get; set; } = true;
        public string Prefix { get; set; } = "{lightred}[HealthPack]";
        public bool DropAnnounce { get; set; } = true;
        public bool PickupAnnounce { get; set; } = true;
    }
    public Config_Chat Chat { get; set; } = new Config_Chat();

    public class Config_Sounds
    {
        public bool Enabled { get; set; } = true;
        public string PickupSound { get; set; } = "sounds/buttons/blip1.vsnd";
        public string PickupFailSound { get; set; } = "sounds/buttons/button8.vsnd";
        public bool SoundEvents { get; set; } = false;
        public string SoundEvent { get; set; } = "soundevents/healthpacks.vsndevts";
        public string PickupEvent { get; set; } = "pack_pickup";
        public string PickupFailEvent { get; set; } = "pack_pickupfail";
    }
    public Config_Sounds Sounds { get; set; } = new Config_Sounds();

    public bool Debug { get; set; } = false;
}