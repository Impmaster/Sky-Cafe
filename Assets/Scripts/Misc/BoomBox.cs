using UnityEngine;
using System.Collections;

public class BoomBox : MonoBehaviour {

	public LookAt lookAt;
	AudioSource audioSrc;

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
				if (Input.GetKeyDown(KeyCode.E)) {
					//If it's activated

					if (audioSrc.isPlaying) {
						audioSrc.Stop();
					} else audioSrc.Play();

				}
			}
		}
	
	}
}
