using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sonigon;

public class ReverbZoneTrigger : MonoBehaviour
{

    public enum ReverbZone
    {
        Default,
        Cave,
        Ship,
        Canyon,
        Mountains
    }
    public ReverbZone MyReverb;
    private void OnTriggerEnter(Collider other)
    {
        

        // do stuff here on entering the trigger.
        switch (MyReverb)
        {
            case ReverbZone.Default:
              //  gunshotHandler.convolutionSwitcherEvent.SetParameter("ReverbZone", 0);
                break;
            case ReverbZone.Cave:
              //  gunshotHandler.convolutionSwitcherEvent.SetParameter("ReverbZone", 1);
                break;

            case ReverbZone.Ship:
              //  gunshotHandler.convolutionSwitcherEvent.SetParameter("ReverbZone", 2);
                break;

            case ReverbZone.Canyon:
              //  gunshotHandler.convolutionSwitcherEvent.SetParameter("ReverbZone", 3);
                break;

            case ReverbZone.Mountains:
              //  gunshotHandler.convolutionSwitcherEvent.SetParameter("ReverbZone", 4);
                break;
            default:
                break;
        }
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
