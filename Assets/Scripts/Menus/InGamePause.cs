using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGamePause : MonoBehaviour {

	public GUIStyle bgSt, bttnSt, txtSt;

	private bool isPause;

	Rect ScToRect (float x, float y, float w, float h) {
		float wi = Screen.width, he = Screen.height;
		return new Rect (x * wi / 100f, y * he / 100f, w * wi / 100f, h * he / 100f);
	}

	// Use this for initialization
	void Start () {
		isPause = false;
	}

	void OnGUI () {
		if (isPause) {
			GUI.Label (ScToRect (0, 0, 100, 100), "", bgSt);
			GUI.Label (ScToRect (20, 10, 60, 10), "MENU", txtSt);
			if (GUI.Button (ScToRect (38, 35, 24, 10), "Resume", bttnSt)) {
				isPause = false;
				Time.timeScale = 1;
			}
			if (GUI.Button (ScToRect (38, 50, 24, 10), "Restart", bttnSt))
				Application.LoadLevel (Application.loadedLevelName);
			if (GUI.Button (ScToRect (38, 65, 24, 10), "Menu", bttnSt))
				Application.LoadLevel ("Menu");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPause = !isPause;
			if (!isPause)
				Time.timeScale = 1;
		}
		if (isPause)
			Time.timeScale = 0;
	}
}
