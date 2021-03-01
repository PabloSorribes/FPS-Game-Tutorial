using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundReflection_", menuName = "Sonigon/SoundReflection", order = 5)]
	public class SoundReflectionData : ScriptableObject
	{
		[FMODUnity.EventRef]
		[SerializeField]
		private string reflectionEvent;

	}
}