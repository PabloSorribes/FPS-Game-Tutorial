using FMODUnity;
using UnityEngine;

public class AudioDelayNetworkManager : MonoBehaviour
{
	[SerializeField]
	private StudioEventEmitter delayNetworkSnapshot = null;
    [SerializeField]
	private AudioRaycaster audioRaycaster = null;

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
		float centerHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.Center);

		float frontLeftHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.FrontLeft);
		float frontRightHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.FrontRight);

		float backLeftHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.BackLeft);
		float backRightHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.BackRight);

        float up = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.Up);

		FMOD.Studio.EventInstance instance = delayNetworkSnapshot.EventInstance;
		instance.setParameterByName("Delay_Center", centerHitDistance);
		instance.setParameterByName("Delay_FrontLeft", frontLeftHitDistance);
		instance.setParameterByName("Delay_FrontRight", frontRightHitDistance);
		instance.setParameterByName("Delay_BackLeft", backLeftHitDistance);
		instance.setParameterByName("Delay_BackRight", backRightHitDistance);
	}
}
