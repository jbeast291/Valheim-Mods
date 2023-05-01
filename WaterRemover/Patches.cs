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
using UnityStandardAssets;

namespace WaterRemover
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Update")]
    internal class PatchIsTeleportable
    {
        [HarmonyPrefix]
        public static void Postfix(Player __instance)
        {
            if(Vars.WaterRemoverLoopActive)
            {
                __instance.m_canSwim = false;
            }
            if (Vars.WaterRestorerLoopActive)
            {
                __instance.m_canSwim = true;
            }
        }
    }
}
