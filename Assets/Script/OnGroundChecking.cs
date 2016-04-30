using UnityEngine;
using System.Collections;

public class OnGroundChecking : MonoBehaviour
{
	#region Init

	public string groundTag = "Ground";

	void Awake()
	{
		var collider = GetComponent<Collider2D>();
		if (collider == null)
		{
			Debug.LogWarning("OnGroundChecking must attack to object that have collider2D, object : " + name);
			Destroy(this);
		}
		else
		{
			collider.isTrigger = true;
		}
	}

	#endregion




	#region Public
	bool _isOnGround = false;

	public bool IsOnGround()
	{
		return _isOnGround;
	}

	#endregion




	#region Working

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == groundTag)
		{
			_isOnGround = true;
		}
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == groundTag)
		{
			_isOnGround = false;
		}
	}

	#endregion
}
