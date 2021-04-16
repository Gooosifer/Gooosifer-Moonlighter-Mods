using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace WeaponEvery30Sec
{
    public static class HeroMerchantInventoryExtension
    {
		/// <summary>
		/// Set the current equipped weapon.
		/// </summary>
		/// <param name="__this"></param>
		/// <param name="weapon"></param>
		public static void OnlySetWeapon(this HeroMerchantInventory __this, ItemStack weapon)
		{
			__this.SetEquippedItemByType(weapon, HeroMerchantInventory.EquipmentSlot.Weapon1);
		}

		/// <summary>
		/// Returns the the current equipped weapon as an ItemStack object. 
		/// [slot: 1 = weapon slot 1; 2 = weapon slot 2]
		/// </summary>
		/// <param name="__this"></param>
		/// <param name="slot"></param>
		/// <returns></returns>
		public static ItemStack GetCurrentlyEquippedWeapon(this HeroMerchantInventory __this, string weaponName, int slot = 1)
        {
			/*switch (slot)
            {
				case 1:
					return HeroMerchant.Instance.heroMerchantInventory.GetEquippedItemByType(HeroMerchantInventory.EquipmentSlot.Weapon1);
					
				case 2:
					return HeroMerchant.Instance.heroMerchantInventory.GetEquippedItemByType(HeroMerchantInventory.EquipmentSlot.Weapon2);
				default:
					return null;
			}*/

			string[] delim = { "(", ")" };

			//string weaponString = HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString();

			string[] words = weaponName.Split(delim, System.StringSplitOptions.RemoveEmptyEntries);

			ItemMaster weapon = ItemDatabase.GetItemByName(words[1]);
			// Creates an instance of the weapon
			ItemStack backup = ItemStack.Create(weapon);
			if (backup != null)
            {
				return backup;
			}
			else
            {
				return null;
            }
			

		}
	}
}
