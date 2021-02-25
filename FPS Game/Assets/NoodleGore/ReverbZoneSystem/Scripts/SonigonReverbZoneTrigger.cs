using UnityEngine;

namespace Sonigon
{
	public class SonigonReverbZoneTrigger : MonoBehaviour
	{
		[SerializeField]
		SoundTagReverbOutdoor reverbTag = null;

		SonigonReverbZoneManager sonigonReverbZoneManager;

		private void Start()
		{
			FindObjectOfType<SonigonReverbZoneManager>();
		}

		private void OnTriggerEnter(Collider other)
		{

		}

		private void OnTriggerExit(Collider other)
		{
			// do stuff here when exiting trigger.
		}
	}
}
