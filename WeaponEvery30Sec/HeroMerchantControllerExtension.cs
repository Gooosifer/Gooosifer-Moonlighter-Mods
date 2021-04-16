using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Random = UnityEngine.Random;

namespace WeaponEvery30Sec
{
    public static class HeroMerchantControllerExtension
    {
		/// <summary>
		/// Set the current equipped weapon.
		/// </summary>
		/// <param name="__this"></param>
		/// <param name="weapon"></param>
		public static void randomWeaponsEveryNSeconds(this HeroMerchantController __this, HeroMerchantInventory __heroInstance)
		{
            
            //ItemStack currentlyEquipped = HeroMerchant.Instance.heroMerchantInventory.GetCurrentlyEquippedWeapon(weaponString);
            int index;


            // beginning of time function

            List<ItemMaster> itemMasters = new List<ItemMaster>();

            // Grabs the index of the weapon from WeaponEquipmentMaster
            itemMasters = ItemDatabase.GetItems().FindAll(item => item is WeaponEquipmentMaster);
            index = Random.Range(0, itemMasters.Count);

            ItemMaster itemName = null;
            int counter = 0;

            // Assign random weapon to itemName variable
            foreach (var weapon_ in itemMasters)
            {
                if (counter == index)
                {
                    itemName = weapon_;
                }
                counter++;
            }

            // Creates an instance of the weapon
            ItemStack weapon = ItemStack.Create(itemName);
            
            // Replaces current weapon with new one
            __heroInstance.OnlySetWeapon(weapon);
            System.Console.WriteLine(HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString());


            counter = 0;
            //endtimefunction
        }
    }
}
