using HarmonyLib;

using UnityEngine;

using flanne.Core;

namespace BetterUI;

class PowerupDisplay : MonoBehaviour
{
	[HarmonyPrefix]
	[HarmonyPatch(typeof(PowerupMenuState), "Enter")]
	private static void PowerupMenuStateEnterPrePatch(GameController ___owner)
	{
		if (BetterUI.configPowerupDisplay.Value)
			___owner.powerupListUI.Show();
	}

	[HarmonyPostfix]
	[HarmonyPatch(typeof(PowerupMenuState), "EndLevelUpAnimationCR")]
	private static void EndLevelUpAnimationCRPostPatch(GameController ___owner)
	{
		___owner.powerupListUI.Hide();
	}
}
