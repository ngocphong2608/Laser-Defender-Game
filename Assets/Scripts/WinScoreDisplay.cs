using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScoreDisplay : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Text score = GameObject.Find ("ScoreValue").GetComponent<Text>();
		score.text = ScoreKeeper.scores.ToString ();
		ScoreKeeper.Reset ();
	}

}
