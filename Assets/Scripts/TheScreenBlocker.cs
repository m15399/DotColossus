using UnityEngine;
using System.Collections;

/// <summary>
/// Blocks on sides of screen to force aspect ratio
/// </summary>
[ExecuteInEditMode]
public class TheScreenBlocker : MonoBehaviour {

	public bool flipped = false;

	void Update () {
		// Position block based on GameManager's screen size
		//
		float x = -TheGameManager.screenWidth / 2.0f;
		if(flipped)
			x *= -1;
		
		transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
	}
}
