using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Outdoor_", menuName = "Sonigon/SoundTagAmb_Outdoor", order = 5)]
	public class SoundTagAmbOutdoor : SoundTagAmbBase
	{
		public enum AmbienceZoneOutdoor
		{
			Default = 0,
			Forest = 1,
			Urban = 2,
			Field = 3,
		}

		public AmbienceZoneOutdoor ambienceZone;

		public override int GetIntParameterValue()
		{
			return (int)ambienceZone;
		}
	}
}