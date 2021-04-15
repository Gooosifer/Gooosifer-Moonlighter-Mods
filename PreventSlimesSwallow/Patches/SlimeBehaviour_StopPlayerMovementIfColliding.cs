using HarmonyLib;
using UnityEngine;

namespace PreventSlimesSwallow.Patches
{
    [HarmonyPatch(typeof(SlimeBehaviour), nameof(SlimeBehaviour.StopPlayerMovementIfColliding))]
    internal class SlimeBehaviour_StopPlayerMovementIfColliding
    {
        [HarmonyPrefix]
        internal static bool Prefix(SlimeBehaviour __instance)
        {
            __instance.isPlayerAbsorbed = false;
            return false;
        }

        [HarmonyPostfix]
        internal static void Postfix(SlimeBehaviour __instance)
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