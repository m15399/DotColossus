﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utils {

	static Dictionary<string, GameObject> found = new Dictionary<string, GameObject>();

	public static GameObject Find(string name){
		if(found.ContainsKey(name)){
			GameObject o = found[name];
			if(o == null || o.Equals(null)){
				found[name] = GameObject.Find(name);
			}
			return o;

		} else {
			found[name] = GameObject.Find(name);
			return found[name];
		}
	}

	public static Vector3 CameraPos {
		get {
			return Camera.main.transform.position;
		}
	}

	public static bool OutOfCamera(Vector3 p, float tolerance){
		p = p - CameraPos;

		if(Mathf.Abs(p.x) > (TheGameManager.screenWidth/2.0f + tolerance) ||
			Mathf.Abs(p.y) > (TheGameManager.screenHeight/2.0f + tolerance)){
			return true;
		}
		return false;
	}

	public static bool OutOfCamera(Vector3 p){
		return OutOfCamera(p, 2);
	}

	// "Passed" the camera
	public static bool OffCamera(Vector3 p){
		p = p - CameraPos;
		return p.y > 20;
	}

	public static void TrackWithCamera(Transform t){
		t.SetParent(Camera.main.transform);
	}

	public static void CancelTrackWithCamera(Transform t){
		t.SetParent(null);
	}

	public static void KillAllBullets(){
		GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
		foreach(GameObject o in bullets){
			GameObject.Destroy(o.gameObject);
		}
	}

}