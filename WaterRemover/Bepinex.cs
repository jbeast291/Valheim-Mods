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
                if(!Vars.WaterRemoverLoopActive)
                {
                    Vars.WaterRemoverLoopActive = true;
                    StartCoroutine(RemoveWaterLoop());
                }
                if (Vars.WaterRestorerLoopActive)
                {
                    Vars.WaterRestorerLoopActive = false;
                    StopCoroutine(RestoreWaterLoop());
                }
            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                RestoreWater();
                if (!Vars.WaterRestorerLoopActive)
                {
                    Vars.WaterRestorerLoopActive = true;
                    StartCoroutine(RestoreWaterLoop());
                }
                if (Vars.WaterRemoverLoopActive)
                {
                    Vars.WaterRemoverLoopActive = false;
                    StopCoroutine(RemoveWaterLoop());
                }
            }
        }
        public void RemoveWater()
        {
            Debug.Log("Removed Water");
            for (int i = 0; i < 20; i++)
            {
                GameObject Water;
                Water = GameObject.Find("Water");
                if (Water == null)
                {
                    continue;
                }
                Water.transform.GetChild(0).gameObject.SetActive(false);
                Water.transform.GetChild(1).gameObject.SetActive(false);
                Water.name = "WaterDISABLED";
            }
        }
        public void RestoreWater()
        {
            Debug.Log("Restored Water");
            for (int i = 0; i < 20; i++)
            {
                GameObject Water;
                Water = GameObject.Find("WaterDISABLED");
                if (Water == null)
                {
                    continue;
                }
                Water.transform.GetChild(0).gameObject.SetActive(true);
                Water.transform.GetChild(1).gameObject.SetActive(true);
                Water.name = "Water";
            }
        }
        IEnumerator RemoveWaterLoop()
        {
            yield return new WaitForSeconds(10);
            if (!Vars.WaterRemoverLoopActive)
            {
                yield break;
            }
            RemoveWater();
            StartCoroutine(RemoveWaterLoop());
        }
        IEnumerator RestoreWaterLoop()
        {
            yield return new WaitForSeconds(10);
            if (!Vars.WaterRestorerLoopActive)
            {
                yield break;
            }
            RestoreWater();
            StartCoroutine(RestoreWaterLoop());
        } 
    }
}
