using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CopyLocalPosition : MonoBehaviour {

	public Transform target;

	void LateUpdate () {
		transform.localPosition = target.localPosition;
	}
}
