using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class AudioGunshotHandler : MonoBehaviour
{
	[FMODUnity.EventRef]
	public string localEvent;

	PhotonView photonView;

	private void Awake()
	{
		photonView = GetComponent<PhotonView>();
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
		FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);
	}
}
