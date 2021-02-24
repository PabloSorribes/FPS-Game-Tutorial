using UnityEngine;

public class AudioRaycaster : MonoBehaviour
{
	public SphereCollider sphereCollider;
	public float maxDistance = 65f;

	[Range(-80f, 0f)]
	public float Reverb_Front = 0f;
	[Range(-80f, 0f)]
	public float Reverb_Center = 0f;
	[Range(-80f, 0f)]
	public float Reverb_Back = 0f;

	public enum AudioReflectionDirection
	{
		Center,
		FrontLeft,
		FrontRight,
		BackLeft,
		BackRight,
        Up
	}

	public float DirectionalRaycast(AudioReflectionDirection reflectionDirection)
	{
		float distanceToObstacle = maxDistance;

		Vector3 origin = transform.position;
		Transform trans = transform;

		Vector3 finalWorldDirection = trans.forward;

        // testing some stuff - Anders
        Vector3 frontLeftWorldDir = transform.position;
        float frontLeftDistance = 0f;

		Color debugColor = Color.red;

		switch (reflectionDirection)
		{
			case AudioReflectionDirection.Center:
				finalWorldDirection = trans.forward;
				debugColor = Color.white;
				break;
			case AudioReflectionDirection.FrontLeft:
				finalWorldDirection = (trans.forward - trans.right).normalized;
                
				debugColor = Color.red;
				break;
			case AudioReflectionDirection.FrontRight:
				finalWorldDirection = (trans.forward + trans.right).normalized;
                frontLeftWorldDir = finalWorldDirection;
				debugColor = Color.blue;
				break;
			case AudioReflectionDirection.BackLeft:
				finalWorldDirection = (-trans.forward - trans.right).normalized;
				debugColor = Color.magenta;
				break;
			case AudioReflectionDirection.BackRight:
				finalWorldDirection = (-trans.forward + trans.right).normalized;
				debugColor = Color.yellow;
				break;

            case AudioReflectionDirection.Up:
                finalWorldDirection = (transform.up.normalized);
                debugColor = Color.cyan;
                break;
        }

		RaycastHit hit;

		// Cast a sphere wrapping character controller 10 meters forward
		// to see if it is about to hit anything.
		if (Physics.SphereCast(origin, sphereCollider.radius, finalWorldDirection, out hit, maxDistance))
		{
			distanceToObstacle = hit.distance;
		}

        if (Physics.SphereCast(origin, sphereCollider.radius, frontLeftWorldDir, out hit, maxDistance))
        {
            frontLeftDistance = hit.distance;
        }
        // figuring out the space using extra superduper quantum mathematics.
        /* 
         * Basically we do this for every cast and then we go "if all these are big and we hit the ceiling, we are inside a huge room"
         * If we are all hitting the walls but it's less distance and we hit the ceiling, we are inside a medium room.
         * If we all hit the walls and we hit the ceiling, we are in a small room.
         */
            //if (frontLeftDistance > 40) Debug.Log("FrontLEft distance is now in a big room");
            //if (frontLeftDistance < 40 & frontLeftDistance > 20) Debug.Log("FrontLEft distance is now in a medium room");
            //if (frontLeftDistance < 20) Debug.Log("FrontLEft distance is now in a small room");
            //if (hit.collider.gameObject !=null) Debug.Log("The collider returned (if any) is " + hit.collider.gameObject.name);
            //Debug.Log("Tag for this collider (if any) is " + hit.transform.tag);
            //Debug.DrawRay(origin, finalWorldDirection * distanceToObstacle, debugColor, 5f);

         Debug.Log($"Direction: {reflectionDirection} | Distance to Obstacle: {distanceToObstacle}");

        

		return distanceToObstacle;

        
	}
}
