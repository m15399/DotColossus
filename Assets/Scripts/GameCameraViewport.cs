using UnityEngine;
using System.Collections;

/// <summary>
/// Changes the size of the game camera to match TheGameManager's screen size
/// </summary>
[ExecuteInEditMode]
public class GameCameraViewport : MonoBehaviour {

	public Camera cam;

	void Update () {

		float screenAspect = ((float)Screen.width) / Screen.height;
		float targetAspect = TheGameManager.screenWidth / TheGameManager.screenHeight;

		float aspectMultiplier = targetAspect / screenAspect;

		Rect rect = new Rect();

		if(aspectMultiplier < 1){
			rect.width = aspectMultiplier;
			rect.height = 1;
			rect.center = new Vector2(.5f, .5f);

		} else {
			// Screen is very portrait-y
			//
			rect.height = 1.0f / aspectMultiplier;
			rect.width = 1;
			rect.center = new Vector2(.5f, .5f);
			rect.y = 1 - rect.height;
		}

		cam.rect = rect;
	}
}
