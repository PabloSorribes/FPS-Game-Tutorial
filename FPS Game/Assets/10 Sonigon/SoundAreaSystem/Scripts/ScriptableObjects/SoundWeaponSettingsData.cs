using UnityEngine;

namespace Sonigon
{
	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundWeaponSettingsData_", menuName = "Sonigon/SoundWeaponSettingsData", order = 5)]
	public class SoundWeaponSettingsData : ScriptableObject, ISoundDataFmodEvent
	{
		[FMODUnity.EventRef]
		[SerializeField]
		private string weaponShotEvent = null;

		[SerializeField]
		private bool enableReflections = true;
		public bool EnableReflections => enableReflections;

		[SerializeField]
		[Range(-80f, 0f)]
		private float reflectionVolumeDB = 0f;
		public float ReflectionVolumeDB => reflectionVolumeDB;

		public string GetFmodEventPath()
		{
			return weaponShotEvent;
		}
	}
}