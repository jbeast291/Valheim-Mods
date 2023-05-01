using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.IO;
using UnityEngine;

namespace WaterRemover
{

    [BepInPlugin(myGUID, pluginName, pluginVersion)]
    public class Bepinex : BaseUnityPlugin
    {
        private const string myGUID = "Jbeast291.WaterRemover";
        private const string pluginName = "Water Remover";
        private const string pluginVersion = "1.0.0";

        private static readonly Harmony harmony = new Harmony(myGUID);

        internal static new ManualLogSource Logger;

        public void Awake()
        {
            Logger = base.Logger;
            Logger.LogInfo(pluginName + " " + pluginVersion + " " + "has been loaded");
            harmony.PatchAll();
        }


        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.F9))
            {
                RemoveWater();
                if (!Vars.WaterRemoverLoopActive)
                {
                    Vars.WaterRemoverLoopActive = true;
                }
                if (Vars.WaterRestorerLoopActive)
                {
                    Vars.WaterRestorerLoopActive = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                RestoreWater();
                if (!Vars.WaterRestorerLoopActive)
                {
                    Vars.WaterRestorerLoopActive = true;
                }
                if (Vars.WaterRemoverLoopActive)
                {
                    Vars.WaterRemoverLoopActive = false;
                }
            }
        }
        public void RemoveWater()
        {
            int Count = 0;
            for (int i = 0; i < 40; i++)
            {
                GameObject Water;
                Water = GameObject.Find("Water");
                if (Water == null)
                {
                    continue;
                }
                Count++;
                Water.transform.GetChild(0).gameObject.SetActive(false);
                Water.transform.GetChild(1).gameObject.SetActive(false);
                Water.name = "WaterDISABLED";
            }
            Logger.LogInfo($"Removed {Count} water tiles");
        }
        public void RestoreWater()
        {
            int Count = 0;
            for (int i = 0; i < 40; i++)
            {
                GameObject Water;
                Water = GameObject.Find("WaterDISABLED");
                if (Water == null)
                {
                    continue;
                }
                Count++;
                Water.transform.GetChild(0).gameObject.SetActive(true);
                Water.transform.GetChild(1).gameObject.SetActive(true);
                Water.name = "Water";
                
            }
            Logger.LogInfo($"Restored {Count} water tiles");
        }
    }
}
