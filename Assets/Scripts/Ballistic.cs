using UnityEngine;
using System.Collections;

/// <summary>
/// Moving object with velocity, friction
/// </summary>
public class Ballistic : MonoBehaviour {

	public float xv = 0, yv = 0;
	public float xFric = 0, yFric = 0;
	public float rv = 0; // Degrees / sec
	public float rFric = 0;
	public bool destroyOffCamera = true;

	void Start () {
		
	}
	
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;

		// Position
		//
		xv *= 1 - xFric;
		yv *= 1 - yFric;

		transform.localPosition += new Vector3(xv * dt, yv * dt, 0);

		// Rotation
		//
		rv *= 1 - rFric;

		transform.Rotate(new Vector3(0, 0, rv * dt));

		// Check if off camera
		//
		if(destroyOffCamera && Utils.OffCamera(transform.position)){
			GameObject.Destroy(gameObject);
		}
	}
}
