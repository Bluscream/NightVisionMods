using MelonLoader;
using System.Net.NetworkInformation;
using UnityEngine;

namespace MelonLoaderMod
{
    public static class BuildInfo
    {
        public const string Name = "Third Person"; // Name of the Mod.  (MUST BE SET)
        public const string Description = ""; // Description for the Mod.  (Set as null if none)
        public const string Author = "Bluscream"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ThirdPersonMod : MelonMod
    {
        private protected static Quaternion QuaternionZero = new Quaternion(0f, 0f, 0f, 0f);
        private protected static Vector3 RelativeThirdPersonCameraPosition;
        private protected static Quaternion RelativeThirdPersonCameraRotation;
        private const string ModCategory = "ThirdPerson";

        public override void OnApplicationStart()
        {
            MelonPrefs.RegisterCategory(this.GetType().Name, BuildInfo.Name);
            MelonPrefs.RegisterFloat(ModCategory, "position.x", .5f, "Position of the third person camera (In relation to the first person camera)");
            MelonPrefs.RegisterFloat(ModCategory, "position.y", .5f, "");
            MelonPrefs.RegisterFloat(ModCategory, "position.z", -7f, "");
            MelonPrefs.RegisterFloat(ModCategory, "rotation.x", 5f, "Rotation of the third person camera (In relation to the first person camera)");
            MelonPrefs.RegisterFloat(ModCategory, "rotation.y", 0f, "");
            MelonPrefs.RegisterFloat(ModCategory, "rotation.z", 0f, "");
            MelonPrefs.RegisterFloat(ModCategory, "rotation.w", 0f, "");
            RelativeThirdPersonCameraPosition = new Vector3(MelonPrefs.GetFloat(ModCategory, "position.x"), MelonPrefs.GetFloat(ModCategory, "position.y"), MelonPrefs.GetFloat(ModCategory, "position.z"));
            RelativeThirdPersonCameraRotation = new Quaternion(MelonPrefs.GetFloat(ModCategory, "rotation.x"), MelonPrefs.GetFloat(ModCategory, "rotation.y"), MelonPrefs.GetFloat(ModCategory, "rotation.z"), MelonPrefs.GetFloat(ModCategory, "rotation.w"));
        }


        private void ToggleThirdPerson()
        {
            if (RoadGen.Instance.insideCamera.transform.localPosition.IsGreaterThan(Vector3.zero))
            {
                MelonLogger.Log("Disabling Third Person ({0} | {1})", RoadGen.Instance.insideCamera.transform.localPosition.ToString(), RoadGen.Instance.insideCamera.transform.localRotation.ToString());
                RoadGen.Instance.insideCamera.transform.localPosition = Vector3.zero;
                RoadGen.Instance.insideCamera.transform.localRotation = QuaternionZero;
            } else {
                MelonLogger.Log("Enabling Third Person");
                RoadGen.Instance.insideCamera.transform.localPosition = RelativeThirdPersonCameraPosition;
                RoadGen.Instance.insideCamera.transform.localRotation = RelativeThirdPersonCameraRotation;
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                ToggleThirdPerson();
            }
        }
    }
    public static class ExtendingVector3
    {
        public static bool IsGreaterThan(this Vector3 local, Vector3 other)
        {
            if (local.x > other.x || local.y > other.y || local.z > other.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    } }