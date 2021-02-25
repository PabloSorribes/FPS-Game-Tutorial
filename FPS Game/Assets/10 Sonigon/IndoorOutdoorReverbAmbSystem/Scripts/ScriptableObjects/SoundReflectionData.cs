using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundReflection_", menuName = "Sonigon/SoundReflection", order = 5)]
	public class SoundReflection : ScriptableObject
	{
		[FMODUnity.EventRef]
		[SerializeField]
		private string reflectionEvent;

	}
}