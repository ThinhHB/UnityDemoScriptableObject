using UnityEngine;
using System.Collections;

public class ReverseRenderer : MonoBehaviour
{
	[Header("The transform will be reverse when user press A/D")]
	public Transform rootRenderTransform = null;

	void Awake()
	{
		if (rootRenderTransform == null)
		{
			Debug.LogWarning("Missing rootRenderTransform !!");
			enabled = false;//disable script
		}
	}

	// Update is called once per frame
	void Update ()
	{
		var scale = rootRenderTransform.localScale;

		if (Input.GetKeyDown(KeyCode.A))
		{
			scale.x = -Mathf.Abs(scale.x);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			scale.x = Mathf.Abs(scale.x);
		}

		rootRenderTransform.localScale = scale;
	}
}