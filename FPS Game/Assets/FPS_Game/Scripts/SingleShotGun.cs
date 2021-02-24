using FMODUnity;
using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
	[SerializeField] Camera cam;


	[Header("--- AUDIO --- ")]
	[SerializeField]
	private StudioEventEmitter snapshotEmitter = null;

	[FMODUnity.EventRef]
	public string localEvent;
	[FMODUnity.EventRef]
	public string serverEvent;

	[SerializeField]
	private AudioRaycaster audioRaycaster = null;


	PhotonView PV;

	void Awake()
	{
		PV = GetComponent<PhotonView>();

		snapshotEmitter.Play();
	}

	public override void Use()
	{
		Shoot();
    }

	float updateInterval = 0.1f;
	float currentIntervalTime = 0.0f;

	private void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;


		currentIntervalTime += Time.deltaTime;

		if (currentIntervalTime >= updateInterval)
		{
			UpdateShotReverb();
			currentIntervalTime = 0f;

			Debug.Log($"UPDATE Reverb");
		}

	}

	void Shoot()
	{
		// Play Shoot Sound for local player
		FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);

		// Send out event to play the SEPARATE server shoot sound on everyone else's computer.
		PV.RPC(nameof(RPC_ServerShootAudio), RpcTarget.Others);
	}

    [PunRPC]
	private void RPC_ServerShootAudio()
	{
		FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);
	}

	private void UpdateShotReverb()
	{
		float centerHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.Center);

		float frontLeftHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.FrontLeft);
		float frontRightHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.FrontRight);

		float backLeftHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.BackLeft);
		float backRightHitDistance = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.BackRight);

        float up = audioRaycaster.DirectionalRaycast(AudioRaycaster.AudioReflectionDirection.Up);

		FMOD.Studio.EventInstance instance = snapshotEmitter.EventInstance;

		instance.setParameterByName("Delay_Center", centerHitDistance);

		instance.setParameterByName("Delay_FrontLeft", frontLeftHitDistance);
		instance.setParameterByName("Delay_FrontRight", frontRightHitDistance);

		instance.setParameterByName("Delay_BackLeft", backLeftHitDistance);
		instance.setParameterByName("Delay_BackRight", backRightHitDistance);
	}
}
