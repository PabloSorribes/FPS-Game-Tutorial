using FMODUnity;
using UnityEngine;

public class AudioReverbZoneManager : MonoBehaviour
{
	[Header("--- Events --- ")]
    [SerializeField]
    private StudioEventEmitter ReverbZoneSnapshotSwitcherEvent = null;

	void Awake()
	{
        ReverbZoneSnapshotSwitcherEvent.Play();
	}

	private void Update()
	{
        HandleReverbZones();
    }

    private void HandleReverbZones()
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
