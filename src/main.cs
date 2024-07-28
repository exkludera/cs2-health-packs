using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;

namespace HealthPacks
{
    public partial class HealthPacks : BasePlugin, IPluginConfig<Config>
    {
        public override string ModuleName => "Health Packs";
        public override string ModuleAuthor => "exkludera";
        public override string ModuleDescription => "dead players drop health packs";
        public override string ModuleVersion => "1.0.2";

        public override void Load(bool hotReload)
        {
            RegisterEventHandler<EventRoundStart>(RoundStart);
            RegisterEventHandler<EventPlayerDeath>(PlayerDeath);
            RegisterListener<Listeners.OnTick>(TickCalculatePack);
            RegisterListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);
        }

        public override void Unload(bool hotReload)
        {
            RemoveListener<Listeners.OnTick>(TickCalculatePack);
            RemoveListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);
        }

        public Config Config { get; set; } = new Config();
        public void OnConfigParsed(Config config)
        {
            Config = config;
            Config.Chat.Prefix = StringExtensions.ReplaceColorTags(Config.Chat.Prefix);
            maxPackCount = Config.Entity.MaxCount;
        }
    }
}
