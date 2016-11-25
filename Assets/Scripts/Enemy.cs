using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 150f;
	public GameObject laser;

	float laserSpeed = 5f;
	float shotsPerSecond = 0.5f;

	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void Fire() {
		Vector3 offset = new Vector3 (0f, -0.5f, 0f);
		GameObject beam = Instantiate (laser, transform.position + offset, Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0f, -laserSpeed, 0f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		PlayerLaser missile = col.gameObject.GetComponent<PlayerLaser> ();
		if (missile) {
			health -= missile.GetDamage ();
			if (health <= 0) {
				Destroy (gameObject);
			}
			missile.Hit();
		}
	}
}
