using UnityEngine;
using System.Collections;

public class DestroyWhenOffCamera : MonoBehaviour {
	
	void Update () {
		if(Utils.OffCamera(transform.position)){
			GameObject.Destroy(gameObject);
		}
	}
}
