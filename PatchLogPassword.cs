using CodeHorizon.BanHamma;
using HarmonyLib;


namespace grtgTest {
  [HarmonyPatch(typeof(SaveSystem.CheckPointManagerBase), "QuickSave")]
  public class PatchLogPassword {
    public static void Prefix(ref SaveSystem.CheckPointManagerBase __instance) {
      var type = typeof(SaveSystem.SaveManager);
      string pass = (string)type.GetField("Pass", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
      Plugin.Logger.LogInfo("QuickSave called! Password: " + pass);
    }
  }

  // [HarmonyPatch(typeof(BanHammaChecker), "IsPlayerBanned")]
  // public class PatchBanHamma {
  //   public static bool Prefix(ref BanHammaChecker __instance, ref bool __result) {
  //     Plugin.Logger.LogInfo("IsPlayerBanned called!");
  //     var type = typeof(BanHammaChecker);
  //     BanHammaManager manager = (BanHammaManager)type.GetField("_manager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(__instance);
  //     var type2 = typeof(SaveSystem.SaveManager);
  //     string pass = (string)type2.GetField("Pass", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).GetValue(null);
  //     manager.InvokePlayerFoundOnBanList("lmao", "so the save password is " + pass);
  //     __result = true; // we're always banned!!
  //     return false; // Always return false
  //   }
  // }
}