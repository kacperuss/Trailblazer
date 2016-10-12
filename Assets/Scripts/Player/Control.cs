using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float maxXPos = 6f;
	public float xSpeed = 10f;

	public float minJump = 8f;
	public float maxJump = 16f;

	public Transform cam;

	private float jumpHeight;

	// Use this for initialization
	void Start () {
		jumpHeight = 0;
	}

	void jump () {
		if (transform.position.y > 0.5f && transform.position.y < 0.6f) {
			if (Input.GetAxis ("Jump") > 0)
				jumpHeight = minJump + Input.GetAxis ("Jump") * (maxJump - minJump);
			else {
				if (jumpHeight != 0) {
					gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, jumpHeight, 0);
					jumpHeight = 0;
				}
			}
		}
	}

	void movePos () {
		transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * xSpeed, 0, 0);

		if (transform.position.x > maxXPos)
			transform.position = new Vector3 (maxXPos, transform.position.y, transform.position.z);
		if (transform.position.x < -maxXPos)
			transform.position = new Vector3 (-maxXPos, transform.position.y, transform.position.z);
	}

	void moveCam () {
		cam.localPosition = new Vector3 (transform.position.x / 2f, cam.position.y, cam.position.z);
	}

	// Update is called once per frame
	void Update () {
		jump ();
		movePos ();
		moveCam ();

		if (Input.GetAxis ("Restart") != 0)
			Application.LoadLevel (Application.loadedLevelName);
	}
}
