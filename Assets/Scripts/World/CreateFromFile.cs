using UnityEngine;
using System.Collections;

public class CreateFromFile : MonoBehaviour {

	public string fileName;

	public GameObject floorPrefab, finishPrefab;

	public Material[] materials;

	private string[] parts;

	private float curZPos;

	void loadParts () {
		TextAsset temp = Resources.Load (fileName) as TextAsset;
		string temp2 = temp.text;
		parts = temp2.Split ('\n');
	}

	void createLevel () {
		for (int i = parts.Length-1; i >= 0; --i) {
			float curXPos = -6;
			for (int j = 0; j < parts [i].Length; ++j) {
				if (parts [i] [j] == '1') {
					GameObject a = GameObject.Instantiate (floorPrefab, new Vector3 (curXPos, 0, curZPos), Quaternion.Euler (Vector3.zero), transform) as GameObject;
					if (i % 2 == j % 2)
						a.GetComponent<MeshRenderer> ().material = materials [0];
					else
						a.GetComponent<MeshRenderer> ().material = materials [1];
				}
				curXPos += 3;
			}
			curZPos += 5;
		}
		gameObject.GetComponent<WinOrDie> ().winPos = curZPos + 5;
		GameObject.Instantiate (finishPrefab, new Vector3 (0, 0, curZPos + 15), Quaternion.Euler (Vector3.zero), transform);
	}

	// Use this for initialization
	void Start () {
		loadParts ();
		createLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
