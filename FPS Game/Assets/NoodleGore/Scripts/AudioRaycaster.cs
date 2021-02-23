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
		BackRight
	}

	public float DiagonalRaycast(AudioReflectionDirection reflectionDirection)
	{
		float distanceToObstacle = maxDistance;

		Vector3 origin = transform.position;
		Transform trans = transform;

		Vector3 finalWorldDirection = trans.forward;
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
		}

		RaycastHit hit;

		// Cast a sphere wrapping character controller 10 meters forward
		// to see if it is about to hit anything.
		if (Physics.SphereCast(origin, sphereCollider.radius, finalWorldDirection, out hit, maxDistance))
		{
			distanceToObstacle = hit.distance;
		}

		Debug.Log($"Direction: {reflectionDirection} | Distance to Obstacle: {distanceToObstacle}");
		Debug.DrawRay(origin, finalWorldDirection * distanceToObstacle, debugColor, 5f);

		return distanceToObstacle;
	}
}
