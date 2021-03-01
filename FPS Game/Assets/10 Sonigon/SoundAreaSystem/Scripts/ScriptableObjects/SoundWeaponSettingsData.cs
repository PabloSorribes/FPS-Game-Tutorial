using UnityEngine;

namespace Sonigon
{
	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundWeaponSettingsData_", menuName = "Sonigon/SoundWeaponSettingsData", order = 5)]
	public class SoundWeaponSettingsData : ScriptableObject, ISoundDataFmodEvent, ISoundDataParameterFloat
	{
		[FMODUnity.EventRef]
		[SerializeField]
		private string weaponShotEvent = null;

		[SerializeField]
		private float reflectionIntensity = 1f;

		public string GetFmodEventPath()
		{
			return weaponShotEvent;
		}

		public float GetFloatParameterValue()
		{
			return reflectionIntensity;
		}
	}
}