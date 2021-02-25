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

		public void AddOutdoorZone(SoundTagReverbBase zoneInfo)
		{
			//Debug.Log($"ADD ZONE: {zoneInfo.reverbType} = {(int)zoneInfo.reverbType}");
			currentTriggerZones_Outdoor.Add(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void RemoveOutdoorZone(SoundTagReverbBase zoneInfo)
		{
			//Debug.Log($"REMOVE ZONE: {zoneInfo.reverbType} = {(int)zoneInfo.reverbType}");
			currentTriggerZones_Outdoor.Remove(zoneInfo);
			UpdateReverbSnapshotParameter();
		}

		public void UpdateReverbSnapshotParameter()
		{
			Debug.Log($"Old Parameter Value: {currentOutdoorParameterValue}");

			// Reset to default if no entries left in the list.
			if (currentTriggerZones_Outdoor.Count == 0)
			{
				currentOutdoorParameterValue = 0;
			}
			else
			{
				currentOutdoorParameterValue = currentTriggerZones_Outdoor[currentTriggerZones_Outdoor.Count - 1].GetParameterValue();
			}

			reverbSnapshotSwitcher_Outdoor.SetParameter("ReverbZone", currentOutdoorParameterValue);
			Debug.Log($"New Parameter Value: {currentOutdoorParameterValue}");
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