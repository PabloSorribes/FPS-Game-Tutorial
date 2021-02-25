using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZoneHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // do stuff here on entering the trigger.
    }

    private void OnTriggerStay(Collider other)
    {
        // do stuff here when inside the trigger (runs in update).
    }

    private void OnTriggerExit(Collider other)
    {
        // do stuff here when exiting trigger.
    }
}
