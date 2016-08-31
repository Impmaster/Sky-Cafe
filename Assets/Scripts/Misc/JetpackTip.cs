using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JetpackTip : MonoBehaviour {
 
	public Text text;

	private bool hasTriggered;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			if (!Input.GetKey(KeyCode.Space)) {
				text.text = "Double Jump and hold to activate your jetpack.";

			}
			hasTriggered = true;
			StartCoroutine(wait());
		}
	}

	void Update() {
		if (hasTriggered) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				text.text = "";
				gameObject.SetActive(false);
			}
		}
	}

	IEnumerator wait() {
		yield return new WaitForSeconds(3);
		text.text = "";
	}
}
