using UnityEngine;
using Photon.Pun;

namespace Sonigon
{
	public class SonigonReverbZoneTrigger : MonoBehaviour
	{
		[SerializeField]
		private bool isIndoor = false;

		[SerializeField]
		SoundTagReverbBase reverbTag = null;

		[SerializeField]
		BoxCollider trigger = null;

		private SonigonReverbZoneManager reverbZoneManager;

		#region Debug
		[Header("--- DEBUG ---")]
		[SerializeField]
		Color debugColor = Color.cyan;

		[SerializeField]
		Material debugMaterial = null;

		[SerializeField]
		[Range(0, 1)]
		float debugAlpha = 0.2f;
		#endregion Debug

		//SonigonReverbZoneManager sonigonReverbZoneManager;
		//SonigonReverbZoneManager SonigonReverbZoneManager
		//{
		//	get
		//	{
		//		if (sonigonReverbZoneManager == null)
		//			sonigonReverbZoneManager = FindObjectOfType<SonigonReverbZoneManager>();
		//		return sonigonReverbZoneManager;
		//	}
		//}

		public void SetReverbZoneManager(SonigonReverbZoneManager reverbZoneManager)
		{
			this.reverbZoneManager = reverbZoneManager;
		}

		private void Start()
		{
			var meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.enabled = true;

			Material material = new Material(debugMaterial);
			Color debugColorTemp = new Color(debugColor.r, debugColor.g, debugColor.b, debugAlpha);

			material.color = debugColorTemp;
			meshRenderer.material = material;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				if (reverbZoneManager.PhotonView.IsMine)
				{
					Debug.Log($"Local player entered, execute stuff here!");

					var sonigonReverbZoneManager = other.GetComponentInChildren<SonigonReverbZoneManager>();

					if (isIndoor)
						sonigonReverbZoneManager.AddIndoorZone(this.reverbTag);
					else
						sonigonReverbZoneManager.AddOutdoorZone(this.reverbTag);

				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				if (reverbZoneManager.PhotonView.IsMine)
				{
					Debug.Log($"Local player exited, execute stuff here!");


					var sonigonReverbZoneManager = other.GetComponentInChildren<SonigonReverbZoneManager>();

					if (isIndoor)
						sonigonReverbZoneManager.RemoveIndoorZone(this.reverbTag);
					else
						sonigonReverbZoneManager.RemoveOutdoorZone(this.reverbTag);
				}
			}
		}

		private void OnDrawGizmos()
		{
			Color debugColorTemp = new Color(debugColor.r, debugColor.g, debugColor.b, debugAlpha);
			Gizmos.color = debugColorTemp;
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawCube(trigger.center, trigger.size);
		}
	}
}
