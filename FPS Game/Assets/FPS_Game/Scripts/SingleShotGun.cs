using UnityEngine;

public class SingleShotGun : Gun
{
	[SerializeField] Camera cam;
	[SerializeField] AudioGunshotHandler gunshotHandler;

	public override void Use()
	{
		gunshotHandler.Shoot();
	}
}
