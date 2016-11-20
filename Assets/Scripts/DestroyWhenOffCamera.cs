using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy object when the game has passed it and it's off screen
/// </summary>
public class DestroyWhenOffCamera : MonoBehaviour {
	
	void Update () {
		if(Utils.OffCamera(transform.position)){
			GameObject.Destroy(gameObject);
		}
	}
}
