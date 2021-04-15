using HarmonyLib;
using UnityEngine;

namespace PreventSlimesSwallow.Patches
{
    [HarmonyPatch(typeof(NormalSlimeBehaviour), nameof(NormalSlimeBehaviour.ChooseAndApplyAction))]
    internal class NormalSlimeBehaviour_ChooseAndApplyAction
    {
        [HarmonyPrefix]
        internal static bool Prefix(NormalSlimeBehaviour __instance)
        {
            
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(NormalSlimeBehaviour __instance)
        {
            /*
			HeroMerchant instance = HeroMerchant.Instance;

			instance.heroMerchantController.isTrapped = false;
			if (!instance.heroMerchantStats.isDead && Time.realtimeSinceStartup - __instance.timeLastExpell > __instance.timeBetweenAbsortions && __instance.enemy.enemyStats.isAlive && !instance.heroMerchantController.isTrapped && !instance.heroMerchantController.currentEquipedAbility.isInUse)
			{
				instance.heroMerchantController.isTrapped = false;
				__instance.enemyAnimator.SetTrigger(null);
				__instance.hasHeroMerchantTrapped = false;
				__instance.isReleasing = true;
			}*/
		}
    }
}