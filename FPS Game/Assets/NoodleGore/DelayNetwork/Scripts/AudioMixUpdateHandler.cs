using FMODUnity;
using UnityEngine;

public class AudioMixUpdateHandler : MonoBehaviour
{
	[Header("--- Events --- ")]
	[SerializeField]
	private StudioEventEmitter delayNetworkSnapshot = null;
    [SerializeField]
    private StudioEventEmitter convolutionSwitcherEvent = null;

	[Header("--- Other Components --- ")]
    [SerializeField]
	private AudioRaycaster audioRaycaster = null;

	float updateInterval = 0.2f;
	float currentIntervalTime = 0.0f;

	void Awake()
	{
		delayNetworkSnapshot.Play();
        convolutionSwitcherEvent.Play();
	}

	private void Update()
	{
		//TODO - Remove this in the proper implementation
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		currentIntervalTime += Time.deltaTime;

		if (currentIntervalTime >= updateInterval)
		{
			UpdateDelayNetwork();
			currentIntervalTime = 0f;
        }

        HandleReverbZones();
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

    private void HandleReverbZones()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            convolutionSwitcherEvent.SetParameter("ReverbZone", 0);
            Debug.Log("reverb set:  Default");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            convolutionSwitcherEvent.SetParameter("ReverbZone", 1);
            Debug.Log("reverb set:  IndoorCave");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            convolutionSwitcherEvent.SetParameter("ReverbZone", 2);
            Debug.Log("reverb set:  IndoorShip");
        }


        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            convolutionSwitcherEvent.SetParameter("ReverbZone", 3);
            Debug.Log("reverb set:  OutdoorCanyon");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            convolutionSwitcherEvent.SetParameter("ReverbZone", 4);
            Debug.Log("reverb set:  OutdoorMountains");
        }
    }
}
