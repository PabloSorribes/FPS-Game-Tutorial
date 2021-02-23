using FMODUnity;
using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
	[SerializeField]
	private StudioEventEmitter snapshotEmitter = null;

	[FMODUnity.EventRef]
	public string localEvent;
	[FMODUnity.EventRef]
	public string serverEvent;

	[SerializeField] Camera cam;

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
		snapshotEmitter.SetParameter("TremoloParam", 0f);

		// Send out event to play the local shoot sound on everyone else's computer.
		PV.RPC(nameof(RPC_ServerShootAudio), RpcTarget.Others);

		Debug.Log($"LocalPlayer: {PhotonNetwork.LocalPlayer.ActorNumber}");
	}

    [PunRPC]
	private void RPC_ServerShootAudio()
	{
		FMODUnity.RuntimeManager.PlayOneShot(serverEvent, transform.position);
		snapshotEmitter.SetParameter("TremoloParam", 1f);
		Debug.Log($"ServerPlayer: {PhotonNetwork.LocalPlayer.ActorNumber}");


		if (!PhotonNetwork.LocalPlayer.IsLocal)
		{
			
		}
	}
}
