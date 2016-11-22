using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Sets an array of life images to enabled or disabled, based on the number of player lives
/// </summary>
public class UILifeContainer : MonoBehaviour {

	public Image[] lives;

	void Update () {
		for(int i = 0; i < lives.Length; i++){
			lives[i].enabled = TheGameManager.playerLives > i;
		}
	}
}
