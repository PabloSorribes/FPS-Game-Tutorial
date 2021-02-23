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
		float centerHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.Center);

		float frontLeftHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.FrontLeft);
		float frontRightHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.FrontRight);

		float backLeftHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.BackLeft);
		float backRightHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.BackRight);

		FMOD.Studio.EventInstance instance = snapshotEmitter.EventInstance;

		instance.setParameterByName("Delay_Center", centerHitDistance);

		instance.setParameterByName("Delay_FrontLeft", frontLeftHitDistance);
		instance.setParameterByName("Delay_FrontRight", frontRightHitDistance);

		instance.setParameterByName("Delay_BackLeft", backLeftHitDistance);
		instance.setParameterByName("Delay_BackRight", backRightHitDistance);
	}
}
