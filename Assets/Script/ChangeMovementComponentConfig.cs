using UnityEngine;
using System.Collections;

public class ChangeMovementComponentConfig : MonoBehaviour
{
	/// Will apply to movmenetComponent
	public MovementConfig config;

	void Awake()
	{
		if (config == null)
		{
			Debug.LogWarning("ChangeMovementCOnfig, missing config !!!", gameObject);
			Destroy(this);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		var impactRigid = col.attachedRigidbody;
		if (impactRigid != null)
		{
			var movementComponent = impactRigid.GetComponent<MovementComponent>();
			if (movementComponent != null)
			{
				movementComponent.ChangeMovementConfig(config);
			}
		}
	}
}
