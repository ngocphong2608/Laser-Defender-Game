using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	Text txtScore;

	// Use this for initialization
	void Start () {
		txtScore = GetComponent<Text>();
		txtScore.text = ScoreKeeper.scores.ToString ();
	}
	
	public void Score(int points) {
		ScoreKeeper.Score (points);
		txtScore.text = ScoreKeeper.scores.ToString ();
	}
}
