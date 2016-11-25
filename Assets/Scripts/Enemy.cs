using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float health = 150f;

	void OnTriggerEnter2D(Collider2D col) {
		Laser missile = col.gameObject.GetComponent<Laser> ();
		if (missile) {
			health -= missile.GetDamage ();
			if (health <= 0) {
				Destroy (gameObject);
			}
			missile.Hit();
		}
	}
}
