using UnityEngine;
using System.Collections;

public class ThePlayer : MonoBehaviour {

	const float accel = 1.25f;
	const float fric = .2f;
	const float maxSpeed = 4f;

	public GameObject tail;

	Vector3 respawnPosition;

	public float xv, yv;

	void Start () {
		respawnPosition = transform.localPosition;
		Reset();
	}

	void Reset(){
		transform.localPosition = respawnPosition;

		xv = 0;
		yv = 3.5f;

		tail.GetComponent<TrailRenderer>().Clear();
	}
	
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;

		// Get inputs
		//
		bool left = Input.GetButton("Left");
		bool right = Input.GetButton("Right");

		// Move direction
		//
		float move = 0;
		move -= left ? 1 : 0;
		move += right ? 1 : 0;

		// Update xv based on move direction
		//
		xv += move * accel;
		xv *= 1 - fric;

		float ms = maxSpeed;

		if(Mathf.Abs(xv) > ms)
		{
			xv = xv > 0 ? ms : -ms;
		}

		// Move player
		//
		transform.localPosition += new Vector3(xv * dt, yv * dt, 0);

		// Clamp to bounds of screen
		//
		float sw = TheGameManager.screenWidth/2;
		Vector3 pos = transform.localPosition;
		if(pos.x < -sw)
			pos.x = -sw;
		if(pos.x > sw)
			pos.x = sw;
		transform.localPosition = pos;

//		Debug.Log("Player velocity: " + Utils.RoundToPlaces(xv, 2) + ", " + Utils.RoundToPlaces(yv, 2));
	}

	void Update(){
		// Debug keys
		//
		if(Input.GetKeyDown("r")){
			Reset();
		}
	}

	void OnTriggerStay2D(Collider2D other){
		HitByEnemy();
	}

	void HitByEnemy(){
		Reset();
		Utils.KillAllBullets();
	}
}
