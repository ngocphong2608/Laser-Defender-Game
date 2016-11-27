using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int scores = 0;

	public static void Score (int points) {
		scores += points;
	}

	public static void Reset() {
		scores = 0;
	}
}
