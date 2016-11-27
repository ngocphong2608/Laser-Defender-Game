using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public int scores = 0;

	private Text txtScore;

	// Use this for initialization
	void Start () {
		txtScore = GetComponent<Text> ();
		txtScore.text = "0";
	}

	public void Score (int points) {
		scores += points;
		txtScore.text = scores.ToString ();
	}

	public void Reset() {
		scores = 0;
		txtScore.text = scores.ToString ();
	}
}
