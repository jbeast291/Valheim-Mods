using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using System.Reflection;
using System.Collections;
using System.IO;
using UnityEngine;

namespace FishLagFix
{
    [HarmonyPatch(typeof(Fish))]
    [HarmonyPatch("Awake")]
    internal class PatchAwakeFish
    {
        [HarmonyPrefix]
        public static bool Postfix(Fish __instance)
        {
            //__instance.transform.gameObject.GetComponent<ZNetView>().Destroy();
            //UnityEngine.Object.Destroy(__instance);
            __instance.transform.localScale = Vector3.one;
            Debug.Log("Set scale of fish to 1. (spam is normal for this)");
            return false;
        }
    }
    [HarmonyPatch(typeof(Fish))]
    [HarmonyPatch("FixedUpdate")]
    internal class PatchFixedUpdateFish
    {
        [HarmonyPrefix]
        public static bool prefix(Fish __instance)
        {
            return false;
        }
    }
    [HarmonyPatch(typeof(Fish))]
    [HarmonyPatch("Start")]
    internal class PatchStartFish
    {
        [HarmonyPrefix]
        public static bool prefix(Fish __instance)
        {
            return false;
        }
    }
}