using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Outdoor_", menuName = "Sonigon/SoundTagAmb_Outdoor", order = 5)]
	public class SoundTagAmbOutdoor : SoundTagAmbBase
	{
		public enum AmbienceZone
		{
			Forest,
			Urban,
			Field
		}

		public AmbienceZone ambienceZone;

		public override int GetParameterValue()
		{
			return (int)ambienceZone;
		}
	}
}