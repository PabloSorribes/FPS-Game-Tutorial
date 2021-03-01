using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class AudioGunshotHandler : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string localEvent;
	[FMODUnity.EventRef]
	public string debugEvent;

	PhotonView photonView;

	private void Awake()
	{
		photonView = GetComponent<PhotonView>();
	}

	private void Update()
	{
		//TODO - Remove this in the proper implementation
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void Shoot()
	{
		// Play Shoot Sound for local player
		FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);

		// Send out event to play the SEPARATE server shoot sound on everyone else's computer.
		photonView.RPC(nameof(RPC_ServerShootAudio), RpcTarget.Others);
	}

	[PunRPC]
	private void RPC_ServerShootAudio()
	{
		if (photonView.IsMine)
		{
			// Perform stuff here that should only be executed locally
			FMODUnity.RuntimeManager.PlayOneShot(debugEvent, transform.position);

		}
		else
		{
			FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);
		}
	}
}
