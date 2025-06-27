using BepInEx;
using BepInEx.Logging;
using eradev.stolenrealm.BetterExploration.Features;
using HarmonyLib;
using JetBrains.Annotations;

namespace eradev.stolenrealm.BetterExploration
{
    [BepInDependency("eradev.stolenrealm.CommandHandler")]
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class BetterExplorationPlugin : BaseUnityPlugin
    {
        // ReSharper disable once NotAccessedField.Global
        public static ManualLogSource LOG;

        [UsedImplicitly]
        private void Awake()
        {
            LOG = Logger;

            BetterTreasures.Register(Config);
            CustomizedMovementSpeed.Register(Config);
            MiniGamesAutoCompletion.Register(Config);
            UnlockFortunesForParty.Register(Config);

            new Harmony(PluginInfo.PLUGIN_GUID).PatchAll();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
