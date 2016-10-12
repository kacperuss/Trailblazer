using UnityEngine;
using System.Collections;

public class StartCount : MonoBehaviour {
	
	public GUIStyle txtSt;

	private bool start;

	Rect ScToRect (float x, float y, float w, float h) {
		float wi = Screen.width, he = Screen.height;
		return new Rect (x * wi / 100f, y * he / 100f, w * wi / 100f, h * he / 100f);
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		start = false;
	}

	void OnGUI () {
		if (!start)
			GUI.Label (ScToRect (20, 10, 60, 10), "Press SPACE to start", txtSt);
	}

	// Update is called once per frame
	void Update () {
		if (!start && Input.GetKey (KeyCode.Space)) {
			start = true;
			Time.timeScale = 1;
		}
	}
}
