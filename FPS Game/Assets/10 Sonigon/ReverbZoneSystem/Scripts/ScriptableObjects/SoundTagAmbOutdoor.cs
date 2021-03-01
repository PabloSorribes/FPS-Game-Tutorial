using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Outdoor_", menuName = "Sonigon/SoundTagAmb_Outdoor", order = 5)]
	public class SoundTagAmbOutdoor : SoundTagBase
	{
		public enum AmbienceZone
		{
			Forest,
			Urban,
			Field
		}

		public AmbienceZone ambienceZone;

		public int GetAmbience()
		{
			return (int)ambienceZone;
		}
	}
}