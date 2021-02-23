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


    bool isServer = false;
	void Awake()
	{
		PV = GetComponent<PhotonView>();

		snapshotEmitter.Play();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isServer = true;
            Debug.Log("tremolo 1.");
           // snapshotEmitter.SetParameter("TremoloParam", 1f);

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            isServer = false;
            Debug.Log("tremolo 0");
           // snapshotEmitter.SetParameter("TremoloParam", 0f);
        }
    }

    public override void Use()
	{
		Shoot();
    }

	void Shoot()
	{
        if (!isServer)
        {
            FMODUnity.RuntimeManager.PlayOneShot(localEvent, transform.position);
            snapshotEmitter.SetParameter("TremoloParam", 0f);
        }

        else RPC_ServerShootAudio();

        // snapshotEmitter.SetParameter("TremoloParam", 0f);

        //      PV.RPC(nameof(RPC_ServerShootAudio), RpcTarget.All);

        //Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        //ray.origin = cam.transform.position;
        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
        //	hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
        //	PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
        //}
    }

    [PunRPC]
	private void RPC_ServerShootAudio()
	{
		FMODUnity.RuntimeManager.PlayOneShot(serverEvent, transform.position);
        snapshotEmitter.SetParameter("TremoloParam", 1f);
    }

    [PunRPC]
	void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
	{
		Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
		if (colliders.Length != 0)
		{
			GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
			Destroy(bulletImpactObj, 10f);
			bulletImpactObj.transform.SetParent(colliders[0].transform);
		}
	}
}
