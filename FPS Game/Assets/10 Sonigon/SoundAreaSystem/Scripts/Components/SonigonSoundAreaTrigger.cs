using Photon.Pun;
using UnityEngine;

namespace Sonigon
{
	public class SonigonSoundAreaTrigger : MonoBehaviour
	{
		[SerializeField]
		SoundTagReverbBase reverbTag = null;
		[SerializeField]
		SoundTagAmbBase ambienceTag = null;

#if UNITY_EDITOR || UNITY_DEVELOPMENT

		[Header("--- DEBUG ---")]
		[SerializeField]
		bool showInGame = false;

		[SerializeField]
		bool drawDebug = false;

		[SerializeField]
		[NaughtyAttributes.ShowIf(nameof(drawDebug))]
		BoxCollider trigger = null;

		[SerializeField]
		[NaughtyAttributes.ShowIf(nameof(drawDebug))]
		Color debugColor = Color.cyan;

		[SerializeField]
		[NaughtyAttributes.ShowIf(nameof(drawDebug))]
		Material debugMaterial = null;

		[SerializeField]
		[NaughtyAttributes.ShowIf(nameof(drawDebug))]
		[Range(0, 1)]
		float debugAlpha = 0.2f;
#endif

		private void Start()
		{
#if UNITY_EDITOR || UNITY_DEVELOPMENT
			if (showInGame)
			{
				var meshRenderer = gameObject.AddComponent<MeshRenderer>();
				meshRenderer.enabled = true;

				Material material = new Material(debugMaterial);
				Color debugColorTemp = new Color(debugColor.r, debugColor.g, debugColor.b, debugAlpha);

				material.color = debugColorTemp;
				meshRenderer.material = material;
			}
#endif
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				if (other.GetComponent<PhotonView>().IsMine)
				{
					Debug.Log($"Local player entered, execute stuff here!");


					var sonigonReverbZoneManager = other.GetComponentInChildren<SonigonSoundAreaManager>();

					if (reverbTag.IsIndoor)
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
				if (other.GetComponent<PhotonView>().IsMine)
				{
					Debug.Log($"Local player exited, execute stuff here!");


					var sonigonReverbZoneManager = other.GetComponentInChildren<SonigonSoundAreaManager>();

					if (reverbTag.IsIndoor)
						sonigonReverbZoneManager.RemoveIndoorZone(this.reverbTag);
					else
						sonigonReverbZoneManager.RemoveOutdoorZone(this.reverbTag);
				}
			}
		}


#if UNITY_EDITOR || UNITY_DEVELOPMENT
		private void OnDrawGizmos()
		{
			if (!drawDebug)
			{
				return;
			}
			Color debugColorTemp = new Color(debugColor.r, debugColor.g, debugColor.b, debugAlpha);
			Gizmos.color = debugColorTemp;
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawCube(trigger.center, trigger.size);
		}
#endif
	}
}
