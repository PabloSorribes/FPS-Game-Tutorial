using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Indoor_", menuName = "Sonigon/SoundTagAmbIndoor", order = 5)]
	public class SoundTagAmbIndoor : SoundTagAmbBase
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