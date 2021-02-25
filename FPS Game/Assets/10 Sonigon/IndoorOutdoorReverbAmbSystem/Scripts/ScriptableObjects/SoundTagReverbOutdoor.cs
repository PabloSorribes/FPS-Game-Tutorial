using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagReverb_Outdoor_", menuName = "Sonigon/SoundTagReverb_Outdoor", order = 5)]
	public class SoundTagReverbOutdoor : SoundTagReverbBase
	{
		public enum ReverbZone_Outside
		{
			Default,
			Canyon,
			Mountains,
			ReactorHall,
			TennisCourt,
		}

		public ReverbZone_Outside reverbType;

		public override int GetParameterValue() => (int)reverbType;
	}
}