using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace AlwaysAllowTeleport
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Humanoid))]
        [HarmonyPatch("IsTeleportable")]
        internal class PatchIsTeleportable
        {
            [HarmonyPrefix]
            public static bool Postfix(ref bool __result)
            {
                __result = true;
                return false;
            }
        }
    }
}