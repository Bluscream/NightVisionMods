using MelonLoader;
using UnityEngine.UI;

namespace MelonLoaderMod
{
    public static class BuildInfo
    {
        public const string Name = "EnableStory"; // Name of the Mod.  (MUST BE SET)
        public const string Description = ""; // Description for the Mod.  (Set as null if none)
        public const string Author = "Bluscream"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class EnableStoryMod : MelonMod
    {

        public override void OnLevelWasInitialized(int buildindex) // Runs when a Scene has Initialized.
        {
            switch (buildindex)
            {
                case 1:
                    MainMenu.Instance.menuCanvas.GetComponentInChildren<Button>().interactable = true;
                    break;
                default:
                    break;
            }
        }
    }
}