using FMODUnity;
using UnityEngine;

namespace Sonigon
{
	public class SonigonDelayNetworkManager : MonoBehaviour
	{
		[SerializeField]
		private StudioEventEmitter delayNetworkSnapshot = null;
		[SerializeField]
		private SonigonAudioRaycaster audioRaycaster = null;

		float updateInterval = 0.2f;
		float currentIntervalTime = 0.0f;

		void Awake()
		{
			delayNetworkSnapshot.Play();
		}

		private void Update()
		{
			currentIntervalTime += Time.deltaTime;

			if (currentIntervalTime >= updateInterval)
			{
				UpdateDelayNetwork();
				currentIntervalTime = 0f;
			}
		}

		private void UpdateDelayNetwork()
		{
			float centerHitDistance = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.Center);

			float frontLeftHitDistance = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.FrontLeft);
			float frontRightHitDistance = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.FrontRight);

			float backLeftHitDistance = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.BackLeft);
			float backRightHitDistance = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.BackRight);

			float up = audioRaycaster.DirectionalRaycast(SonigonAudioRaycaster.AudioReflectionDirection.Up);

			FMOD.Studio.EventInstance instance = delayNetworkSnapshot.EventInstance;
			instance.setParameterByName("Delay_Center", centerHitDistance);
			instance.setParameterByName("Delay_FrontLeft", frontLeftHitDistance);
			instance.setParameterByName("Delay_FrontRight", frontRightHitDistance);
			instance.setParameterByName("Delay_BackLeft", backLeftHitDistance);
			instance.setParameterByName("Delay_BackRight", backRightHitDistance);
		}
	}
}