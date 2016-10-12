using UnityEngine;
using System.Collections;

public class CreateEndless : MonoBehaviour {

	public bool isItFirst;

	public string childTag;

	public GameObject floorPrefab;

	public Material[] materials;

	private string[] parts;

	private float curZPos;

	void createLevel () {
		for (int i = 0; i < parts.Length ; ++i) {
			float curXPos = -6;
			for (int j = 0; j < parts [i].Length; ++j) {
				if (parts [i] [j] == '1') {
					GameObject a = GameObject.Instantiate (floorPrefab, new Vector3 (curXPos, 0, curZPos), Quaternion.Euler (Vector3.zero), transform) as GameObject;
					a.tag = childTag;
					if (i % 2 == j % 2)
						a.GetComponent<MeshRenderer> ().material = materials [0];
					else
						a.GetComponent<MeshRenderer> ().material = materials [1];
				}
				curXPos += 3;
			}
			curZPos += 5;
		}
		gameObject.GetComponent<WinOrDie> ().winPos = -1;
	}

	void firstRand () {
		parts = new string[50];
		if (isItFirst) {
			isItFirst = false;
			parts [0] = "11111";
			parts [1] = "11111";
			parts [2] = "11111";
			for (int i = 3; i < 50; ++i) {
				string a = "";
				for (int j = 0; j < 5; ++j)
					a += (char)('0' + Random.Range (0, 4) - 1);
				parts [i] = a;
			}
		} else {
			for (int i = 0; i < 50; ++i) {
				string a = "";
				for (int j = 0; j < 5; ++j)
					a += (char)('0' + Random.Range (0, 4) - 1);
				parts [i] = a;
			}
		}
	}

	void Start () {
		curZPos = transform.position.z;
		firstRand ();
		createLevel ();
	}

	void removeLast () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag (childTag);
		for (int i = temp.Length - 1; i >= 0; --i) {
			Destroy (temp [i]);
		}
		curZPos = transform.position.z;
	}

	void Update () {
		if (transform.position.z <= -250f) {
			transform.Translate (0, 0, 500f);
			removeLast ();
			firstRand ();
			createLevel ();
		}
	}
}
