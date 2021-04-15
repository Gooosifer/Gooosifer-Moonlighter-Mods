using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Reflection;

namespace PreventSlimesSwallow
{
    [BepInPlugin("Goosifer.PreventSlimesSwallow", "PreventSlimesSwallow", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        internal static Main instance;
        internal static Assembly modAssembly = Assembly.GetExecutingAssembly();
        internal static string modName = $"{modAssembly.GetName().Name}";
        internal static string modDir = $"{Environment.CurrentDirectory}\\BepInEx\\{modName}";

        void Awake()
        {
            new Harmony($"Goosifer_{modName}").PatchAll(modAssembly);
            Logger.LogInfo($"{modName} has loaded");
        }

        void Update()
        {

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