using UnityEngine;
using System.Collections;

public class ThePlayer : MonoBehaviour {

	const float accel = 1.25f;
	const float fric = .2f;
	const float maxSpeed = 5f;

	Vector3 respawnPosition;

	public float xv, yv;

	void Start () {
		respawnPosition = transform.localPosition;
		Reset();
	}

	void Reset(){
		transform.localPosition = respawnPosition;

		xv = 0;
		yv = -3.5f;
		// yv = 0;
	}
	
	void FixedUpdate () {
		float dt = Time.fixedDeltaTime;

		bool left = Input.GetButton("Left");
		bool right = Input.GetButton("Right");

		float move = 0;
		move -= left ? 1 : 0;
		move += right ? 1 : 0;

		xv += move * accel;
		xv *= 1 - fric;

		float ms = maxSpeed;

		if(Mathf.Abs(xv) > ms)
		{
			xv = xv > 0 ? ms : -ms;
		}

		transform.localPosition += new Vector3(xv * dt, yv * dt, 0);

		float sw = TheGameManager.screenWidth/2;
		Vector3 pos = transform.localPosition;
		if(pos.x < -sw)
			pos.x = -sw;
		if(pos.x > sw)
			pos.x = sw;
		transform.localPosition = pos;
	}

	void Update(){
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
