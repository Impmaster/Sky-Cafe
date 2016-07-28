using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideBoundary : MonoBehaviour {

	[SerializeField]
	private Transform resetPos;

	[SerializeField]
	private Text text;

	

	public ScreenFader fader;

	public float time = 1;

	void Start() {
		time = fader.fadeTime;
	}

	

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			text.text = "";
			StartCoroutine(FadeOut(other));
		}
	}

	private IEnumerator FadeOut(Collider other) {
		fader.fadeIn = false;
		yield return new WaitForSeconds(time);
		other.transform.position = resetPos.position; 
		other.transform.rotation = resetPos.rotation;
		fader.fadeIn = true;
	}
}
