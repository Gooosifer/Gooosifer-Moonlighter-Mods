using HarmonyLib;
using UnityEngine;

namespace WeaponEvery30Sec.Patches
{
    [HarmonyPatch(typeof(MainMenuPanel), nameof(MainMenuPanel.Awake))]
    internal class MainMenuPanel_Enable
    {
        [HarmonyPrefix]
        internal static bool Prefix(MainMenuPanel __instance)
        {

            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(MainMenuPanel __instance)
        {

        }
    }
}