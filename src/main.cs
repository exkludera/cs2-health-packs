using CounterStrikeSharp.API.Core;

namespace HealthPacks
{
    public partial class HealthPacks : BasePlugin, IPluginConfig<ConfigSettings>
    {
        public override string ModuleName => "Health Packs";
        public override string ModuleAuthor => "exkludera";
        public override string ModuleDescription => "dead players drop health packs";
        public override string ModuleVersion => "1.0";

        public override void Load(bool hotReload)
        {
            Prefix = Config.Chat.Prefix;
            maxPackCount = Config.Entity.MaxCount;
            RegisterEventHandler<EventRoundStart>(RoundStart);
            RegisterEventHandler<EventPlayerDeath>(PlayerDeath);
            RegisterListener<Listeners.OnTick>(TickCalculatePack);
            RegisterListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);
        }

        public ConfigSettings Config { get; set; } = new ConfigSettings();
        public void OnConfigParsed(ConfigSettings config) { Config = config; }
    }
}
