using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundReflection_", menuName = "Sonigon/SoundReflection", order = 5)]
	public class SoundReflectionData : ScriptableObject
	{
		//[FMODUnity.EventRef]
		//[SerializeField]
		//private string reflectionEvent = null;
		//public string ReflectionEvent => reflectionEvent;

		public enum SoundReflectionType
		{
			Indoor_Dull_Big_Shot = 0,
			Indoor_Dull_Medium_Shot = 1,
			Indoor_Dull_Small_Shot = 2,
			Indoor_Reverbant_Big_Shot = 3,
			Indoor_Reverbant_Huge_Shot = 4,
			Indoor_Reverbant_Medium_Shot = 5,
			Indoor_Reverbant_Small_Shot = 6,
			Outdoor_Outdoor_Field_Shot = 7,
			Outdoor_Outdoor_Forest_Shot = 8,
			Outdoor_Outdoor_Urban_Shot = 9,
		}

		public SoundReflectionType soundReflectionType;
	}
}