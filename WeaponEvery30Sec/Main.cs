using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;


namespace WeaponEvery30Sec
{
    [BepInPlugin("Goosifer.WeaponEvery30Sec", "WeaponEvery30Sec", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        internal static Main instance;
        internal static Assembly modAssembly = Assembly.GetExecutingAssembly();
        internal static string modName = $"{modAssembly.GetName().Name}";
        internal static string modDir = $"{Environment.CurrentDirectory}\\BepInEx\\plugins\\{modName}";
        public float timeRemaining = 10;
        internal static bool hasLoaded = false;

        void Awake()
        {
            instance = this;
            new Harmony($"Goosifer_{modName}").PatchAll(modAssembly);
            Logger.LogInfo($"{modName} has loaded");
            int seed = 1234;
            Random.InitState(seed);
            
        }

        void Update()
        {

            // Saves the current equipped weapon
            //ItemStack currentlyEquipped = HeroMerchant.Instance.heroMerchantInventory.GetCurrentlyEquippedWeapon();
            
            int index;
            if (GameManager.Instance.IsWillInDungeon())
            {
                // Instance of hero merchant inventory
                HeroMerchantInventory __heroInstance = HeroMerchant.Instance.heroMerchantInventory;
                hasLoaded = true;

                if (timeRemaining <= 0)
                {                   
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
                    instance.Logger.LogMessage(HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString());
                    instance.Logger.LogMessage(__heroInstance.GetCurrentlyEquippedWeapon().ToString());

                    timeRemaining = 10;
                    counter = 0;
                }
                timeRemaining -= Time.deltaTime;
            }

            if ((GameManager.Instance.IsTownSceneLoaded() == true) && (hasLoaded == false))
            {
                // Instance of hero merchant inventory
                HeroMerchantInventory __heroInstance = HeroMerchant.Instance.heroMerchantInventory;
                // Restores current weapon
                //__heroInstance.OnlySetWeapon(currentlyEquipped);
                //instance.Logger.LogMessage(currentlyEquipped.ToString());
                hasLoaded = true;
            }
            
        }

        internal static void LogMessage(string message)
        {
            instance.Logger.LogMessage(message);
        }

        internal static void LogError(string message)
        {
            instance.Logger.LogError(message);
        }

        internal static void Log(LogLevel level, string message)
        {
            instance.Logger.Log(level, message);
        }
    }
}