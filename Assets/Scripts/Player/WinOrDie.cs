using UnityEngine;
using System.Collections;

public class WinOrDie : MonoBehaviour {

	public float winPos;

	public Transform ball;

	public GUIStyle bgSt, bttnSt, txtSt;

	public static bool won, die;

	Rect ScToRect (float x, float y, float w, float h) {
		float wi = Screen.width, he = Screen.height;
		return new Rect (x * wi / 100f, y * he / 100f, w * wi / 100f, h * he / 100f);
	}

	// Use this for initialization
	void Start () {
		won = false;
		die = false;
	}

	void OnGUI () {
		if (won) {
			GUI.Label (ScToRect (0, 0, 100, 100), "", bgSt);
			GUI.Label (ScToRect (20, 10, 60, 10), "YOU WIN!", txtSt);
			if (GUI.Button (ScToRect (38, 40, 24, 10), "Try Again", bttnSt))
				Application.LoadLevel (Application.loadedLevelName);
			if (GUI.Button (ScToRect (38, 60, 24, 10), "Menu", bttnSt))
				Application.LoadLevel ("Menu");
		}
		if (die) {
			GUI.Label (ScToRect (0, 0, 100, 100), "", bgSt);
			GUI.Label (ScToRect (20, 10, 60, 10), "YOU DIED!", txtSt);
			if (GUI.Button (ScToRect (38, 40, 24, 10), "Try Again", bttnSt))
				Application.LoadLevel (Application.loadedLevelName);
			if (GUI.Button (ScToRect (38, 55, 24, 10), "Menu", bttnSt))
				Application.LoadLevel ("Menu");
			if (PlayerPrefs.GetInt ("instRes") == 0) {
				if (GUI.Button (ScToRect (38, 80, 24, 10), "Instant restart: NO", bttnSt))
					PlayerPrefs.SetInt ("instRes", 1);
			} else {
				if (GUI.Button (ScToRect (38, 80, 24, 10), "Instant restart: YES", bttnSt))
					PlayerPrefs.SetInt ("instRes", 0);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (winPos > 0 && transform.position.z < -winPos) {
			Time.timeScale = 0;
			won = true;
		}
		if (ball.position.y < -3f) {
			if (PlayerPrefs.GetInt ("instRes") == 0) {
				Time.timeScale = 0;
				die = true;
			} else if (!die)
				Application.LoadLevel (Application.loadedLevelName);
		}
	}
}
