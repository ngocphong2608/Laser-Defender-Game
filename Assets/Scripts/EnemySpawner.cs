﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject obj = Instantiate (enemy, child.position, Quaternion.identity) as GameObject;
			obj.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
