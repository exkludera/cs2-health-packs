using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Health Packs";
    public override string ModuleAuthor => "exkludera";
    public override string ModuleVersion => "1.0.4";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);

        RegisterEventHandler<EventRoundStart>(EventRoundStart);
        RegisterEventHandler<EventPlayerDeath>(EventPlayerDeath);

        HookEntityOutput("trigger_multiple", "OnStartTouch", trigger_multiple, HookMode.Pre);
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);

        DeregisterEventHandler<EventRoundStart>(EventRoundStart);
        DeregisterEventHandler<EventPlayerDeath>(EventPlayerDeath);

        UnhookEntityOutput("trigger_multiple", "OnStartTouch", trigger_multiple, HookMode.Pre);
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
        Config.Chat.Prefix = StringExtensions.ReplaceColorTags(Config.Chat.Prefix);
        maxPackCount = Config.Entity.MaxCount;
    }
}