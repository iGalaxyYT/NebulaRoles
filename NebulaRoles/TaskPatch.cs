﻿using HarmonyLib;
using UnityEngine;
using static NebulaRoles.NebulaLogic;

namespace NebulaRoles
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetTasks))]
    public static class TaskPatch
    {
        static void Postfix(PlayerControl __instance)
        {
            System.Console.WriteLine(PlayerControl.LocalPlayer.GetModdedControl().Role);
            if (PlayerControl.LocalPlayer != null)
            {
                if (PlayerControl.LocalPlayer.IsPlayerRole("Jester"))
                {
                    ImportantTextTask ImportantTasks = new GameObject("JesterTasks").AddComponent<ImportantTextTask>();
                    ImportantTasks.transform.SetParent(__instance.transform, false);
                    ImportantTasks.Text = "[ED54BAFF]Get voted out to win.[]\nNo Tasks";
                    __instance.myTasks.Insert(0, ImportantTasks);
                }
            }
        }
    }
}