using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float seed = 15f;
	public GameObject laser;
	public float laserSpeed = 5f;
	public float firingRate = 0.2f;
	public float health = 250f;

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

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		EnemyLaser missile = col.gameObject.GetComponent<EnemyLaser> ();
		if (missile) {
			health -= missile.GetDamage ();
			if (health <= 0) {
				Destroy (gameObject);
			}
			missile.Hit();
		}
	}

	void Fire() {
		Vector3 offset = new Vector3 (0f, 0.5f, 0f);
		GameObject beam = Instantiate (laser, transform.position + offset, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0f, laserSpeed, 0f);
	}

	void MovePlayerShip(float dx, float dy) {
		Vector3 deltaPos = new Vector3 (dx, dy, transform.position.z);
		//print (newPos);

		this.transform.position += deltaPos * Time.deltaTime;

		float xnew = Mathf.Clamp (this.transform.position.x, xmin, xmax);

		this.transform.position = new Vector3 (xnew, transform.position.y, transform.position.z);
	}
}
