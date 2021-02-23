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

	void Shoot()
	{
		// Play Shoot Sound for local player
		FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);
		FmodHandleShoot();

		// Send out event to play the SEPARATE server shoot sound on everyone else's computer.
		PV.RPC(nameof(RPC_ServerShootAudio), RpcTarget.Others);
	}

    [PunRPC]
	private void RPC_ServerShootAudio()
	{
		FMODUnity.RuntimeManager.PlayOneShot(serverEvent, transform.position);
		snapshotEmitter.SetParameter("TremoloParam", 1f);
	}

	private void FmodHandleShoot()
	{
		float centerHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.Center);

		float frontLeftHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.FrontLeft);
		float frontRightHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.FrontRight);

		float backLeftHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.BackLeft);
		float backRightHitDistance = audioRaycaster.DiagonalRaycast(AudioRaycaster.AudioReflectionDirection.BackRight);

		//FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(localEvent);
		FMOD.Studio.EventInstance instance = snapshotEmitter.EventInstance;

		instance.setParameterByName("Delay_Center", centerHitDistance);

		instance.setParameterByName("Delay_FrontLeft", frontLeftHitDistance);
		instance.setParameterByName("Delay_FrontRight", frontRightHitDistance);

		instance.setParameterByName("Delay_BackLeft", backLeftHitDistance);
		instance.setParameterByName("Delay_BackRight", backRightHitDistance);

		instance.setParameterByName("Reverb_Front", audioRaycaster.Reverb_Front);
		instance.setParameterByName("Reverb_Center", audioRaycaster.Reverb_Center);
		instance.setParameterByName("Reverb_Back", audioRaycaster.Reverb_Back);

		RuntimeManager.PlayOneShot(localEvent, transform.position);

		//instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
		//instance.start();
		//instance.release();
	}


	//if (PhotonNetwork.LocalPlayer.IsLocal)
	//{
	//	// Do stuff if local player
	//}
}
