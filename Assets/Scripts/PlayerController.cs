using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float seed = 15f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
/*		if (Input.GetKey (KeyCode.UpArrow)) {
			MovePlayerShip (0f, seed);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			MovePlayerShip (0f, -seed);
		} else */ if (Input.GetKey (KeyCode.LeftArrow)) {
			MovePlayerShip (-seed, 0f);
		} else if (Input.GetKey (KeyCode.RightArrow)){
			MovePlayerShip (seed, 0f);
		}
	}

	void MovePlayerShip(float dx, float dy) {
		Vector3 deltaPos = new Vector3 (dx, dy, 0f);
		//print (newPos);

		this.transform.position += deltaPos * Time.deltaTime;
	}
}
