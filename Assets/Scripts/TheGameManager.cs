using UnityEngine;
using System.Collections;

public class TheGameManager : MonoBehaviour {

	public static float screenWidth = 7.5f;
	public static float screenHeight = 10.0f;

	static int _playerLives = 3;

	public static int playerLives {
		get {
			return _playerLives;
		}
		set {
			// Clamp the number of lives the player can have
			//
			_playerLives = Mathf.Clamp(value, 0, 5);
		}
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
