using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float seed = 15f;

	float xmin;
	float xmax;
	float padding = 1f;

	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		// calculate xmax and xmin
		xmax = rightMost.x - padding;
		xmin = leftMost.x + padding;
	}

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
		Vector3 deltaPos = new Vector3 (dx, dy, transform.position.z);
		//print (newPos);

		this.transform.position += deltaPos * Time.deltaTime;

		float xnew = Mathf.Clamp (this.transform.position.x, xmin, xmax);

		this.transform.position = new Vector3 (xnew, transform.position.y, transform.position.z);
	}
}
