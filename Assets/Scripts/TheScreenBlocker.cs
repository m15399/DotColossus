using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TheScreenBlocker : MonoBehaviour {

	public bool flipped = false;

	void Update () {
		float x = -TheGameManager.screenWidth / 2.0f;
		if(flipped)
			x *= -1;
		
		transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
	}
}
