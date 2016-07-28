using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JetpackTip : MonoBehaviour {
 
	public Text text;

	private bool hasTriggered;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			text.text = "Hold Space when in the air to activate your jetpack.";
			hasTriggered = true;
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
}
