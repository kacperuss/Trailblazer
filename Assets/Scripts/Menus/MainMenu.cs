using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUIStyle bttnSt, txtSt;

	Rect ScToRect (float x, float y, float w, float h) {
		float wi = Screen.width, he = Screen.height;
		return new Rect (x * wi / 100f, y * he / 100f, w * wi / 100f, h * he / 100f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.Label (ScToRect (20, 10, 60, 10), "TRAILBLAZER", txtSt);
		if (GUI.Button (ScToRect (38, 40, 24, 10), "Level 1", bttnSt))
			Application.LoadLevel ("Level1");
		if (GUI.Button (ScToRect (38, 55, 24, 10), "Endless Mode", bttnSt))
			Application.LoadLevel ("Endless");
		if (PlayerPrefs.GetInt ("instRes") == 0) {
			if (GUI.Button (ScToRect (10, 80, 24, 10), "Instant restart: NO", bttnSt))
				PlayerPrefs.SetInt ("instRes", 1);
		} else {
			if (GUI.Button (ScToRect (10, 80, 24, 10), "Instant restart: YES", bttnSt))
				PlayerPrefs.SetInt ("instRes", 0);
		}
		if (GUI.Button (ScToRect (66, 80, 24, 10), "Exit", bttnSt))
			Application.Quit ();
	}
}
