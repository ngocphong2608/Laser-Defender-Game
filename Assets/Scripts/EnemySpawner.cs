using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;

	float xmax, xmin;
	float padding = 0f;
	bool moveRight = true;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		
		// calculate xmax and xmin
		xmax = rightMost.x - padding;
		xmin = leftMost.x + padding;

		SpawnEnemies ();
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		} else {
			transform.position += Vector3.left * Time.deltaTime * speed;
		}

		float leftEdge = transform.position.x - width / 2;
		float rightEdge = transform.position.x + width / 2;

		if (leftEdge < xmin) {
			moveRight = true;
		} else if (rightEdge > xmax) {
			moveRight = false;
		}

		if (AllEnemiesDead ()) {
			SpawnEnemies();
		}
	}

	bool AllEnemiesDead() {
		foreach (Transform child in transform) {
			if (child.childCount > 0)
				return false;
		}
		return true;
	}

	void SpawnEnemies() {
		foreach (Transform child in transform) {
			GameObject obj = Instantiate (enemy, child.position, Quaternion.identity) as GameObject;
			obj.transform.parent = child;
		}
	}
}
