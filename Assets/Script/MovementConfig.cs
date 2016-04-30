using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "GameConfiguration/PlayerMovement", order = 1)]
public class MovementConfig : ScriptableObject
{
	public float movingAcceleration;
	public float limitMovingSpeed;
	public float jumpSpeed;
}
