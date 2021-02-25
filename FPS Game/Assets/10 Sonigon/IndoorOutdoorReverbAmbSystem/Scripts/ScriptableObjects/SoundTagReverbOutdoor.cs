using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagReverb_Outdoor_", menuName = "Sonigon/SoundTagReverb_Outdoor", order = 5)]
	public class SoundTagReverbOutdoor : SoundTagBase
	{
		public enum ReverbZone
		{
			Default,
			Cave,
			Ship,
			Canyon,
			Mountains
		}

		public ReverbZone reverbType;

		public int GetParameterValue() => (int)reverbType;
	}
}