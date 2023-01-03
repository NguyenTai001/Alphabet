using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "GameConfiguration/PlayerMovement", order = 1)]
public class MovementConfig : ScriptableObject
{
	public float speedMove;
	public float jumpforce;
	public float poins;
}
