using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;
using Random = UnityEngine.Random;
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
        internal static bool comingBackFromDungeon = false;
        internal static bool justEnteredDungeon = true;
        internal static bool heroInstanceLoaded = false;
        static float timeRemaining = 10;
        internal static HeroMerchantInventory __heroInstance;
        internal static string weaponStringBackup;
        internal static string weaponString;

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
            __heroInstance = HeroMerchant.Instance.heroMerchantInventory;          
            if (timeRemaining <= 0)
            {
                if (GameManager.Instance.IsWillInDungeon())
                {
                    if (justEnteredDungeon == true)
                    {
                        weaponStringBackup = HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString();
                        justEnteredDungeon = false;
                    }
                    HeroMerchant.Instance.heroMerchantController.randomWeaponsEveryNSeconds(__heroInstance);
                    weaponString = HeroMerchant.Instance.heroMerchantController.currentEquippedWeapon.ToString();
                    comingBackFromDungeon = true;
                }
                else if (GameManager.Instance.IsWillInTown())
                {                   
                    if ((!weaponString.Equals(weaponStringBackup)) && (comingBackFromDungeon == true))
                    {
                        ItemStack currentlyEquipped = __heroInstance.GetCurrentlyEquippedWeapon(weaponStringBackup);
                        // Restores current weapon
                        if (currentlyEquipped != null)
                        {
                            __heroInstance.OnlySetWeapon(currentlyEquipped);
                        }
                        instance.Logger.LogMessage(currentlyEquipped.ToString());
                        comingBackFromDungeon = false;
                        justEnteredDungeon = true;
                    }
                }
                timeRemaining = 10;
                
            }
            timeRemaining -= Time.deltaTime;
            /*    if (GameManager.Instance.IsDungeonSceneLoaded())
                {
                    if (GameManager.Instance.IsWillInDungeon())
                    {
                        hasLoaded = false;
                    }
                }*/

            /*if ((GameManager.Instance.IsTownSceneLoaded() == true) && (hasLoaded == false))
            {
                // Instance of hero merchant inventory
                //__heroInstance = HeroMerchant.Instance.heroMerchantInventory;
                // Restores current weapon
                if (currentlyEquipped != null)
                {
                    __heroInstance.OnlySetWeapon(currentlyEquipped);
                }
                //instance.Logger.LogMessage(currentlyEquipped.ToString());
                hasLoaded = true;
            }*/

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