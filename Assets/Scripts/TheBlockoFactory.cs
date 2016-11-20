using UnityEngine;
using System.Collections;

public class TheBlockoFactory : MonoBehaviour {

	public GameObject blocko;
	public float rof = 1;
	public float spread = 10;

	void Start () {
		Utils.TrackWithCamera(transform);
		Fire();
	}

	void Fire (){
		float v = Random.Range(-spread, spread);

		GameObject b = GameObject.Instantiate(blocko);
		b.tag = "Bullet";
		b.transform.position = transform.position;
		b.GetComponent<Ballistic>().xv = v;

		Invoke("Fire", 1/rof);
	}

	void Update(){
		
	}

}
