using UnityEngine;
using System.Collections;

public class TheCamera : MonoBehaviour {

	const float adjustPositionSpeed = .5f;
	const float adjustPositionSpeedTween = 1f;

	enum PlayerPosition {
		TOP = 0,
		MIDDLE
	}

	static readonly float[] playerPositions = {
		2.75f,
		0
	};


	float yoff;
	PlayerPosition ppos = PlayerPosition.MIDDLE;

	void Start(){
		Reset();
	}

	void Reset(){
		yoff = 0;
		ppos = PlayerPosition.TOP;
	}

	void LateUpdate () {
		if(Input.GetKeyDown("t"))
			ppos = PlayerPosition.TOP;
		if(Input.GetKeyDown("m"))
			ppos = PlayerPosition.MIDDLE;

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player == null)
			return;

		float targetYoff = -playerPositions[(int)ppos];

		yoff = Mathf.MoveTowards(yoff, targetYoff, adjustPositionSpeed * Time.deltaTime);
		yoff = Mathf.Lerp(yoff, targetYoff, adjustPositionSpeedTween * Time.deltaTime);

		Vector3 pp = player.transform.position;
		Vector3 p = transform.position;
		transform.position = new Vector3(p.x, pp.y + yoff, p.z);
	}
}
