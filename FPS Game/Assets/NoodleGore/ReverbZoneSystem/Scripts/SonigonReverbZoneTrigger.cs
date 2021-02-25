using UnityEngine;

namespace Sonigon
{
	public class SonigonReverbZoneTrigger : MonoBehaviour
	{
        [SerializeField]
		SoundTagReverbBase reverbTag = null;

		[SerializeField]
		BoxCollider trigger = null;

		#region Debug
		[SerializeField]
		Color debugColor = Color.cyan;

		[SerializeField]
		Material debugMaterial = null;

        [SerializeField]
        [Range(0,1)]
		float debugAlpha = 0.2f;
		#endregion Debug

		SonigonReverbZoneManager sonigonReverbZoneManager;

        private void Start()
		{
			sonigonReverbZoneManager = FindObjectOfType<SonigonReverbZoneManager>();

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
				sonigonReverbZoneManager.AddOutdoorZone(this.reverbTag);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				sonigonReverbZoneManager.RemoveOutdoorZone(this.reverbTag);
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
