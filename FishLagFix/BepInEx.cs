using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace FishLagFix
{
    [BepInPlugin(myGUID, pluginName, pluginVersion)]
    public class BepInEx : BaseUnityPlugin
    {
        private const string myGUID = "Jbeast291.FishLagFix";
        private const string pluginName = "Fish Lag Fix";
        private const string pluginVersion = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);

        internal static new ManualLogSource Logger;

        public void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo(pluginName + " " + pluginVersion + " " + "has been loaded");
            harmony.PatchAll();
        }
    }
}