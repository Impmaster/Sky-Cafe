using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class indoors : MonoBehaviour {
	
	//The script that allows flying, to be turned off indoors
	private fly flyScript;
	
	private FirstPersonController movementScript;
	
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player") {
			flyScript = other.gameObject.GetComponent<fly>();
			flyScript.enabled = false;
			
			movementScript = other.gameObject.GetComponent<FirstPersonController>();
			movementScript.setFlying(false);
			movementScript.setJump(false);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "Player") {
			flyScript.enabled = true;
			movementScript.setJump(true);
		}
	}
}
