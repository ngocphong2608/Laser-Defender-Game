using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	AudioSource music;

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource> ();

		if (instance != null) {
			Destroy (gameObject);
			//instance = null;
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);

			music.clip = startClip;
			music.loop = true;
			music.Play ();
		}
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log ("Level was loaded: " + level);
		if (music == null)
			return;

		music.Stop ();

		if (level == 0) {
			music.clip = startClip;
		} else if (level == 1) {
			music.clip = gameClip;
		} else if (level == 2) {
			music.clip = endClip;
		}

		music.loop = true;
		music.Play ();
	}
}
