using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

namespace Sonigon
{
	public class SonigonReverbZoneManager : MonoBehaviour
	{
		[SerializeField]
		private StudioEventEmitter ReverbZoneSnapshotSwitcherEvent = null;

		[SerializeField]
		private List<SoundTagReverbOutdoor> currentTriggerZones = new List<SoundTagReverbOutdoor>();
		private int currentParameterValue = 0;

		void Awake()
		{
			ReverbZoneSnapshotSwitcherEvent.Play();
		}

		public void AddZone(SoundTagReverbOutdoor zoneInfo)
		{
			Debug.Log($"ADD ZONE: {zoneInfo.reverbType} = {(int)zoneInfo.reverbType}");
			currentTriggerZones.Add(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void RemoveZone(SoundTagReverbOutdoor zoneInfo)
		{
			Debug.Log($"REMOVE ZONE: {zoneInfo.reverbType} = {(int)zoneInfo.reverbType}");
			currentTriggerZones.Remove(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void UpdateReverbSnapshotParameter()
		{
			Debug.Log($"Old Parameter Value: {currentParameterValue}");

			// Reset to default if no entries left in the list.
			if (currentTriggerZones.Count == 0)
			{
				currentParameterValue = 0;
			}
			else
			{
				currentParameterValue = currentTriggerZones[currentTriggerZones.Count - 1].GetParameterValue();
			}

			ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", currentParameterValue);
			Debug.Log($"New Parameter Value: {currentParameterValue}");
		}







		

		private void Update()
		{
			DebugSetReverbZones();
		}

		private void DebugSetReverbZones()
		{
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", 0);
				Debug.Log("reverb set:  Default");
			}

			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", 1);
				Debug.Log("reverb set:  IndoorCave");
			}

			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", 2);
				Debug.Log("reverb set:  IndoorShip");
			}


			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", 3);
				Debug.Log("reverb set:  OutdoorCanyon");
			}

			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				ReverbZoneSnapshotSwitcherEvent.SetParameter("ReverbZone", 4);
				Debug.Log("reverb set:  OutdoorMountains");
			}
		}
	}
}