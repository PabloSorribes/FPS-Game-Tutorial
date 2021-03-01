using UnityEngine;

namespace Sonigon
{

	[System.Serializable]
	[CreateAssetMenu(fileName = "SoundTagAmb_Indoor_", menuName = "Sonigon/SoundTagAmbIndoor", order = 5)]
	public class SoundTagAmbIndoor : SoundTagBase
	{
		[SerializeField]
		[FMODUnity.EventRef]
		private string indoorAmbienceEvent = null;

		public string IndoorAmbienceEvent => indoorAmbienceEvent;
	}
}