using UnityEngine;
using System.Collections;


public class TheFighter : MonoBehaviour2 {

	const float baseSpeed = 12;
	const float turnSpeed = 250;

	Ballistic ballistic;

	void Start () {
		ballistic = GetComponent<Ballistic>();

		rot = -90;
		Utils.TrackWithCamera(transform);

		StartCoroutine( Script1() );
	}
	
	void Update () {
		float dt = Time.deltaTime;

		ballistic.Accelerate(rot, baseSpeed * dt);

		// Player control
		//
//		if(Input.GetButton("Up")){
//			ballistic.Accelerate(rot, baseSpeed * dt);
//		}
//		if(Input.GetButton("Left")){
//			rot += turnSpeed * dt;
//		}
//		if(Input.GetButton("Right")){
//			rot -= turnSpeed * dt;
//		}
	}

	IEnumerator Script1(){
		yield return StartCoroutine(FlyAtAngle(-90, 1, .9f));
		yield return StartCoroutine(FlyAtAngle(20, 1, .7f));
		yield return StartCoroutine(FlyAtAngle(-100, 1, 1f));
		yield return StartCoroutine(FlyAtAngle(-90, 1, .5f));
	}

	IEnumerator FlyAtAngle(float angle, float turnSpeedMul, float time){
		float endTime = Time.time + time;

		while(true){
			RotateTowards(angle, turnSpeed * turnSpeedMul * Time.deltaTime);

			if(Time.time >= endTime)
				break;

			yield return null;
		}
		yield return null;
	}
}
