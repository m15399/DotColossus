using UnityEngine;
using System.Collections;

/// <summary>
/// Attach a GameObject to a point relative to the screen - (0,0) to (1,1)
/// </summary>
[ExecuteInEditMode]
public class AttachToScreen : MonoBehaviour {

	public Vector2 placement;
	
	void Update () {
		Vector3 pos = transform.localPosition;
		pos.x = placement.x * TheGameManager.screenWidth / 2;
		pos.y = placement.y * TheGameManager.screenHeight / 2;
		transform.localPosition = pos;
	}
}
