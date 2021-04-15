using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;
using System.Linq;


namespace WeaponEvery30Sec
{
    [BepInPlugin("Goosifer.WeaponEvery30Sec", "WeaponEvery30Sec", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        internal static Main instance;
        internal static Assembly modAssembly = Assembly.GetExecutingAssembly();
        internal static string modName = $"{modAssembly.GetName().Name}";
        internal static string modDir = $"{Environment.CurrentDirectory}\\BepInEx\\plugins\\{modName}";
        internal static bool hasLoaded = false;
        void Awake()
        {
            instance = this;
            new Harmony($"Goosifer_{modName}").PatchAll(modAssembly);
            Logger.LogInfo($"{modName} has loaded");
            
            
            

        }

        void Update()
        {
           
            if ((GameManager.Instance.IsTownSceneLoaded()) && (hasLoaded == false))
            {
                // Instance of hero merchant inventory
                HeroMerchantInventory __heroInstance = HeroMerchant.Instance.heroMerchantInventory;

                // Grabs the index of the weapon from WeaponEquipmentMaster
                ItemMaster itemName = ItemDatabase.GetItems().Find(item => item is WeaponEquipmentMaster && item.nameKey == "Big Sword");

                // Creates an instance of the weapon
                ItemStack weapon = ItemStack.Create(itemName);

                // Saves the current equipped weapon
                ItemStack currentEquipped = __heroInstance.GetCurrentEquippedWeapon();

                // Replaces current weapon to new one
                __heroInstance.OnlySetWeapon(weapon);
                instance.Logger.LogMessage(HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString());
                
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