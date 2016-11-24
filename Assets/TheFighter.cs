using UnityEngine;
using System.Collections;


public class TheFighter : MonoBehaviour2 {

	const float speed = 5;
	const float turnSpeed = 250;

		
	void Start () {
		rot = -45;
		Utils.TrackWithCamera(transform);

		StartCoroutine( Script1() );
	}
	
	void Update () {
		MoveForward(speed * Time.deltaTime);
	}

	IEnumerator Script1(){
		yield return StartCoroutine(FlyAt(-90, 1, .5f));
		yield return StartCoroutine(FlyAt(0, .5f, .8f));
		yield return StartCoroutine(FlyAt(-90, 1, .5f));
	}

	IEnumerator FlyAt(float angle, float turnSpeedMul, float time){
		float endTime = Time.time + time;

		while(true){
			RotateTowards(angle, turnSpeed * turnSpeedMul * Time.deltaTime);

			if(Time.time >= endTime)
				break;

			yield return null;
		}
		yield return null;
	}


//
//	IEnumerator FlyTo(Vector2[] destinations){
//		int index = 0;
//
//		while(true){
//			if(index >= destinations.Length)
//				break;
//
//			Vector2 dest = (Vector3)destinations[index];
//			Vector2 pos = transform.localPosition;
//
//			Vector2 delta = dest - pos;
//			float deltaMagnitude = delta.magnitude;
//
//			if(deltaMagnitude < .05)
//				index++;
//
//			RotateTowards(dest, turnSpeed * Time.deltaTime);
////			MoveForward(Mathf.Min(speed * Time.deltaTime, deltaMagnitude));
//
//			yield return null;
//		}
//
//		yield return null;
//	}
}
