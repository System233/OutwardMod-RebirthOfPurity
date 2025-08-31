using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using BepInEx.Logging;

namespace RebirthOfPurity
{
    [BepInPlugin("com.github.system233.rebirthofpurity", "Rebirth Of Purity", "1.0.0")]
    public class RebirthOfPurity : BaseUnityPlugin
    {
        public static ConfigEntry<bool> EnablePurification;
        public static ConfigEntry<float> SleepPurificationRate;
        
        private static ManualLogSource logger=BepInEx.Logging.Logger.CreateLogSource("RebirthOfPurity");
        private readonly static Harmony harmony = new Harmony("com.github.system233.rebirthofpurity");
        void Awake()
        {
            EnablePurification = Config.Bind(
                "",
                "Enable Purification",
                true,
                "Enable or disable corruption cleansing effects."
            );

            SleepPurificationRate = Config.Bind(
                "",
                "Sleep Purification Rate",
                100.0f,
                "Amount of corruption reduced per unit of in-game sleep time."
            );

            harmony.PatchAll();
            logger = BepInEx.Logging.Logger.CreateLogSource("Rebirth Of Purity");
            logger.LogInfo("loaded");
        }
        public static void LogInfo(params object[] args)
        {
            var _logger = logger;
            if (_logger == null)
            {
                return;
            }
            _logger.LogDebug(string.Join(",", args));
        }
    }


    [HarmonyPatch(typeof(Character), "SendResurrect")]
    class Patch_Character_SendResurrect
    {

        static void Postfix(Character __instance)
        {
            if (!RebirthOfPurity.EnablePurification.Value)
            {
                return;
            }
            var self = __instance;
            // self.Stats.CorruptionProtection
            self.PlayerStats.m_corruptionLevel = 0f;

        }
    }
    [HarmonyPatch(typeof(PlayerCharacterStats), "UpdateNeeds")]
    class Patch_PlayerCharacterStats_UpdateNeeds
    {

        static void Postfix(PlayerCharacterStats __instance, object[] __args)
        {
            if (!RebirthOfPurity.EnablePurification.Value)
            {
                return;
            }
            var self = __instance;
            var deltaTime = (float)__args[0];
            // self.Stats.CorruptionProtection
            self.m_corruptionLevel = Mathf.Clamp(self.m_corruptionLevel - deltaTime * RebirthOfPurity.SleepPurificationRate.Value, 0, self.MaxCorruption);

        }
    }

    
}
