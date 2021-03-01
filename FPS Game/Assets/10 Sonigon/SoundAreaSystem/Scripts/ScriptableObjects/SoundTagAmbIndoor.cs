using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Indoor_", menuName = "Sonigon/SoundTagAmbIndoor", order = 5)]
	public class SoundTagAmbIndoor : SoundTagAmbBase
	{
		public enum AmbienceZoneIndoor
		{
			Default = 0,
			Small_House_Default = 1,
			Small_House_Windy = 2,
			Big_Empty = 3,
		}

		public AmbienceZoneIndoor ambienceZone;

		public override int GetIntParameterValue()
		{
			return (int)ambienceZone;
		}
	}
}