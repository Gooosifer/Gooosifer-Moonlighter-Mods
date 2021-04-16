using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace WeaponEvery30Sec
{
    public static class GameManagerExtension
    {
		/// <summary>
		/// Check if Will is in dungeon.
		/// </summary>
		/// <param name="__this"></param>
		public static bool IsWillInTown(this GameManager __this)
		{
			return __this.IsTownSceneLoaded() && !__this.IsDungeonSceneLoaded();
		}
		
	}
}
