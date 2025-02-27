using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using System.Runtime.InteropServices;

public partial class Plugin : BasePlugin, IPluginConfig<Config>
{
    public override string ModuleName => "Health Packs";
    public override string ModuleAuthor => "exkludera";
    public override string ModuleVersion => "1.0.3";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);

        RegisterEventHandler<EventRoundStart>(EventRoundStart);
        RegisterEventHandler<EventPlayerDeath>(EventPlayerDeath);

        HookEntityOutput("trigger_multiple", "OnStartTouch", trigger_multiple, HookMode.Pre);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            EmitSoundExtension.Init();
    }

    public override void Unload(bool hotReload)
    {
        RemoveListener<Listeners.OnServerPrecacheResources>(ServerPrecacheResources);

        DeregisterEventHandler<EventRoundStart>(EventRoundStart);
        DeregisterEventHandler<EventPlayerDeath>(EventPlayerDeath);

        UnhookEntityOutput("trigger_multiple", "OnStartTouch", trigger_multiple, HookMode.Pre);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            EmitSoundExtension.CleanUp();
    }

    public Config Config { get; set; } = new Config();
    public void OnConfigParsed(Config config)
    {
        Config = config;
        Config.Chat.Prefix = StringExtensions.ReplaceColorTags(Config.Chat.Prefix);
        maxPackCount = Config.Entity.MaxCount;
    }
}