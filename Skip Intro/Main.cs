﻿using MelonLoader;
using UnityEngine.SceneManagement;

namespace MelonLoaderMod
{
    public static class BuildInfo
    {
        public const string Name = "Skip Intro"; // Name of the Mod.  (MUST BE SET)
        public const string Description = ""; // Description for the Mod.  (Set as null if none)
        public const string Author = "Bluscream"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class SkipIntroMod : MelonMod
    {
        public override void OnLevelWasInitialized(int buildindex) // Runs when a Scene has Initialized.
        {
            switch (buildindex)
            {
                case 0:
                    MelonLogger.Log("Intro Scene loaded, forcing next scene...");
                    SceneManager.LoadScene(1);
                    break;
                default:
                    break;
            }
        }
    }
}