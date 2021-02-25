using UnityEngine;

namespace Sonigon
{
	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundWeaponSettingsData_", menuName = "Sonigon/SoundWeaponSettingsData", order = 5)]
	public class SoundWeaponSettingsData : ScriptableObject
	{
		[FMODUnity.EventRef]
		[SerializeField]
		public string weaponShotEvent = null;

		[SerializeField]
		public float reflectionIntensity = 1f;

	}
}