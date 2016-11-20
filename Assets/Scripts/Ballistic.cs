using UnityEngine;
using System.Collections;

public class Ballistic : MonoBehaviour {

	public float xv = 0, yv = 0;
	public float xFric = 0, yFric = 0;

	void Start () {
		
	}
	
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;

		xv *= 1 - xFric;
		yv *= 1 - yFric;

		transform.localPosition += new Vector3(xv * dt, yv * dt, 0);
	}
}
