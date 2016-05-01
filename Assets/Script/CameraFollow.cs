using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	#region Init, config

	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

	public Transform followTarget = null;
	private Transform _myTransform;


	void Awake ()
	{
		// cache transform component
		_myTransform = transform;
	}

	#endregion



	#region Public

	public void SetFollowTarget(Transform target)
	{
		followTarget = target;
	}

	#endregion



	#region Working

	bool CheckXMargin ()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(_myTransform.position.x - followTarget.position.x) > xMargin;
	}


	bool CheckYMargin ()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(_myTransform.position.y - followTarget.position.y) > yMargin;
	}


	void FixedUpdate ()
	{
		if (followTarget != null)
			TrackPlayer();
	}


	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = _myTransform.position.x;
		float targetY = _myTransform.position.y;

		// If the player has moved beyond the x margin...
		if (CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(_myTransform.position.x, followTarget.position.x, xSmooth * Time.fixedDeltaTime);

		// If the player has moved beyond the y margin...
		if (CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(_myTransform.position.y, followTarget.position.y, ySmooth * Time.fixedDeltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		// Set the camera's position to the target position with the same z component.
		_myTransform.position = new Vector3(targetX, targetY, _myTransform.position.z);
	}

	#endregion
}
