using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoomBox : MonoBehaviour {

	public LookAt lookAt;

	public Text text;
	AudioSource audioSrc;

	public string tip = "Press E to turn on the music.";

	public AudioClip song;

	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource>();
		audioSrc.clip = song;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (lookAt.inFront(out hit)) {
			if (hit.transform.name == this.name) {
				text.text = tip;
				if (Input.GetKeyDown(KeyCode.E)) {
					//If it's activated

					if (audioSrc.isPlaying) {
						audioSrc.Stop();
					} else audioSrc.Play();

				}
			}
		} else {
			if (text.text == tip) {
				text.text = "";
			}
		}
	
	}
}
