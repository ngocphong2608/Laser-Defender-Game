using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		GameObject obj = Instantiate (enemy, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		obj.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
