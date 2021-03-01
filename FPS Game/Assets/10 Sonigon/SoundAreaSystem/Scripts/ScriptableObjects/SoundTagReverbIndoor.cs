using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagReverb_Indoor_", menuName = "Sonigon/SoundTagReverb_Indoor", order = 5)]
	public class SoundTagReverbIndoor : SoundTagReverbBase
	{
		public enum ReverbZone_Inside
		{
			Default,
			Cave,
			Ship,
			DomesticApartment,
			Basement
		}

		public ReverbZone_Inside reverbType;

		public override int GetIntParameterValue() => (int)reverbType;

	}
}