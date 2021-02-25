using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

namespace Sonigon
{
	public class SonigonReverbZoneManager : MonoBehaviour
	{
		[SerializeField]
		private StudioEventEmitter reverbSnapshotSwitcher_Indoor = null;
		[SerializeField]
		private StudioEventEmitter reverbSnapshotSwitcher_Outdoor = null;

		[SerializeField]
		private List<SoundTagReverbBase> currentTriggerZones_Indoor = new List<SoundTagReverbBase>();
		private int currentIndoorParameterValue = 0;

		[SerializeField]
		private List<SoundTagReverbBase> currentTriggerZones_Outdoor = new List<SoundTagReverbBase>();
		private int currentOutdoorParameterValue = 0;


		void Awake()
		{
			reverbSnapshotSwitcher_Indoor.Play();
			reverbSnapshotSwitcher_Outdoor.Play();
		}

		public void AddIndoorZone(SoundTagReverbBase zoneInfo)
		{
			currentTriggerZones_Indoor.Add(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void RemoveIndoorZone(SoundTagReverbBase zoneInfo)
		{
			currentTriggerZones_Indoor.Remove(zoneInfo);
			UpdateReverbSnapshotParameter();
		}


		public void AddOutdoorZone(SoundTagReverbBase zoneInfo)
		{
			currentTriggerZones_Outdoor.Add(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void RemoveOutdoorZone(SoundTagReverbBase zoneInfo)
		{
			currentTriggerZones_Outdoor.Remove(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void UpdateReverbSnapshotParameter()
		{
			bool isIndoor = false;

			// Reset to default if no entries left in the list.
			if (currentTriggerZones_Indoor.Count == 0)
			{
				currentIndoorParameterValue = 0;
			}
			else
			{
				isIndoor = true;
				currentIndoorParameterValue = currentTriggerZones_Indoor[currentTriggerZones_Indoor.Count - 1].GetParameterValue();

				// Set OutDoor to its Default Value when you are inside a building/room/house etc.
				currentOutdoorParameterValue = 0;
			}

			// Only play the OutDoor snapshot if there isn't any Indoor snapshots left to play
			if (!isIndoor)
			{
				// Reset to default if no entries left in the list.
				if (currentTriggerZones_Outdoor.Count == 0)
				{
					currentOutdoorParameterValue = 0;
				}
				else
				{
					currentOutdoorParameterValue = currentTriggerZones_Outdoor[currentTriggerZones_Outdoor.Count - 1].GetParameterValue();
				}
			}

			UpdateSnapshots();
		}

		private void UpdateSnapshots()
		{
			// Update snapshots
			reverbSnapshotSwitcher_Indoor.SetParameter("ReverbZone", currentIndoorParameterValue);
			reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", currentOutdoorParameterValue);
		}








		private void Update()
		{
			DebugSetReverbZones();
		}

		private void DebugSetReverbZones()
		{
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", 0);
				Debug.Log("reverb set:  Default");
			}

			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", 1);
				Debug.Log("reverb set:  IndoorCave");
			}

			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", 2);
				Debug.Log("reverb set:  IndoorShip");
			}


			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", 3);
				Debug.Log("reverb set:  OutdoorCanyon");
			}

			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", 4);
				Debug.Log("reverb set:  OutdoorMountains");
			}
		}
	}
}