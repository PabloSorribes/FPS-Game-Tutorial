﻿using UnityEngine;

namespace Sonigon
{
	public class SonigonReverbZoneTrigger : MonoBehaviour
	{
		[SerializeField]
		SoundTagReverbOutdoor reverbTag = null;

		[SerializeField]
		BoxCollider trigger = null;

		[SerializeField]
		Color debugColor = Color.cyan;
		[SerializeField]
		float debugAlpha = 0.2f;

		SonigonReverbZoneManager sonigonReverbZoneManager;

		private void Start()
		{
			sonigonReverbZoneManager = FindObjectOfType<SonigonReverbZoneManager>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				sonigonReverbZoneManager.AddZone(this.reverbTag);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				sonigonReverbZoneManager.RemoveZone(this.reverbTag);
			}
		}

		private void OnValidate()
		{
			//name = "ReverbZone_" + reverbTag?.reverbType;
		}

		private void OnDrawGizmos()
		{
			Color debugColorTemp = new Color(debugColor.r, debugColor.g, debugColor.b, debugAlpha);
			Gizmos.color = debugColorTemp;
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawCube(trigger.center, trigger.size);
			//Gizmos.DrawCube(transform.position, transform.localScale);
		}
	}
}
