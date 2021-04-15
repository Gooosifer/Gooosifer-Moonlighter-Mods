using HarmonyLib;
using UnityEngine;

namespace PreventSlimesSwallow.Patches
{
    [HarmonyPatch(typeof(SlimeBehaviour), nameof(SlimeBehaviour.AbsorbPlayer))]
    internal class SlimeBehaviour_AbsorbPlayer
    {
        [HarmonyPrefix]
        internal static bool Prefix(SlimeBehaviour __instance)
        {
            __instance.isPlayerAbsorbed = false;
            HeroMerchant.Instance.heroMerchantController.isTrapped = false;
           
            __instance.buttonCount = 4;
            return false;
        }

        [HarmonyPostfix]
        internal static void Postfix(SlimeBehaviour __instance)
        {
            
           /* __instance.isPlayerAbsorbed = false;
            HeroMerchant.Instance.heroMerchantController.isTrapped = false;
            __instance.enemyAnimator.SetBool("WillAbsorbed", __instance.isPlayerAbsorbed = false);*/
        }
    }
}