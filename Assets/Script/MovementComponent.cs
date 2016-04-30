using UnityEngine;
using System.Collections;

public class MovementComponent : MonoBehaviour
{
	#region Init
	// configuration
	public MovementConfig defaultMovementConfig;
	public OnGroundChecking onGroundChecking;

	// fields
	private MovementConfig _activeMovementConfig;
	Rigidbody2D _myRigidbody;

	void Awake()
	{
		// checking
		if (defaultMovementConfig == null)
		{
			Debug.LogWarning("MovementComponent, misisng default config !!");
			enabled = false;//deactive
		}
		else
		{
			_activeMovementConfig = defaultMovementConfig;
		}

		if (onGroundChecking == null)
		{
			Debug.LogWarning("MovementComponent, misisng onGroundChecking!!");
			enabled = false;//deactive
		}

		// cache
		_myRigidbody = GetComponent<Rigidbody2D>();
		if (_myRigidbody == null)
		{
			Debug.LogWarning("MovementComponent, not found RigidbodyComponent !!");
			enabled = false;//deactive
		}
	}

	#endregion



	#region Public

	public void ChangeMovementConfig(MovementConfig config)
	{
		_activeMovementConfig = config;
	}

	#endregion



	#region Working

	void Update()
	{
		var velo = _myRigidbody.velocity;
		// if player reach limit speed, then do nothing
//		if (Mathf.Abs(velo.x) >= _activeMovementConfig.limitMovingSpeed)
//		{
//			return;
//		}

		// movement
		if (Input.GetKey(KeyCode.A))
		{
			velo.x -= _activeMovementConfig.movingAcceleration * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.D))
		{
			velo.x += _activeMovementConfig.movingAcceleration * Time.deltaTime;
		}

		// Jump
		if (Input.GetKeyDown(KeyCode.W) && onGroundChecking.IsOnGround())
		{
			velo.y = _activeMovementConfig.jumpSpeed;
		}


		// clamp to limit speed
		velo.x = Mathf.Clamp(velo.x, -_activeMovementConfig.limitMovingSpeed, _activeMovementConfig.limitMovingSpeed);
		_myRigidbody.velocity = velo;
	}

	#endregion
}

