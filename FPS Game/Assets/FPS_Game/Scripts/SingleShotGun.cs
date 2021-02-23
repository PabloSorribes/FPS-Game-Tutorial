﻿using FMODUnity;
using Photon.Pun;
using UnityEngine;

public class SingleShotGun : Gun
{
	[SerializeField]
	private StudioEventEmitter snapshotEmitter = null;

	[FMODUnity.EventRef]
	public string gunshotEvent;

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
		Debug.Log($"SHOOT!");

		snapshotEmitter.SetParameter("TremoloParam", 1f);

		FMODUnity.RuntimeManager.PlayOneShot(gunshotEvent, transform.position);

		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
		ray.origin = cam.transform.position;
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
			PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
		}
	}

	[PunRPC]
	void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
	{
		snapshotEmitter.SetParameter("TremoloParam", 0f);
		FMODUnity.RuntimeManager.PlayOneShot(gunshotEvent, transform.position);

		Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
		if (colliders.Length != 0)
		{
			GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
			Destroy(bulletImpactObj, 10f);
			bulletImpactObj.transform.SetParent(colliders[0].transform);
		}
	}
}
