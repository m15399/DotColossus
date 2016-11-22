using UnityEngine;
using System.Collections;

public class TheCamera : MonoBehaviour {

	const float adjustPositionSpeed = .5f; // Constant move-towards speed
	const float adjustPositionSpeedTween = 1f; // Lerp move-towards speed

	// Where the player is vertically
	//
	enum PlayerPosition {
		TOP = 0,
		MIDDLE,
		BOTTOM
	}

	// Vertical coords of player for each PlayerPosition
	//
	const float playerDistFromCenter = 3.0f;
	static readonly float[] playerPositions = {
		playerDistFromCenter,
		0,
		-playerDistFromCenter
	};

	// Current Yoffset from player
	float yoff;

	// Target position (bottom/middle/top)
	PlayerPosition ppos;

	void Start(){
		Reset();
	}

	void Reset(){
		ppos = PlayerPosition.BOTTOM;
		yoff = -playerPositions[(int)ppos];
	}

	void LateUpdate () {
		// Debug keys
		//
		if(Input.GetKeyDown("t"))
			ppos = PlayerPosition.TOP;
		if(Input.GetKeyDown("m"))
			ppos = PlayerPosition.MIDDLE;
		if(Input.GetKeyDown("b"))
			ppos = PlayerPosition.BOTTOM;

		// Figure out what yoff we want to be
		//
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player == null)
			return;

		float targetYoff = -playerPositions[(int)ppos];

		// Tween yoff towards it
		//
		yoff = Mathf.MoveTowards(yoff, targetYoff, adjustPositionSpeed * Time.deltaTime);
		yoff = Mathf.Lerp(yoff, targetYoff, adjustPositionSpeedTween * Time.deltaTime);

		// Update position
		//
		Vector3 pp = player.transform.position;
		Vector3 p = transform.position;
		transform.position = new Vector3(p.x, pp.y + yoff, p.z);
	}
}
