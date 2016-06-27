using UnityEngine;
using System.Collections;

public class holdMug : MonoBehaviour {

	public GameObject MugHolder;

	public GameObject mug;
	[SerializeField]
	private bool isHolding;
	[SerializeField]
	private bool inTrigger;

	void Start() {
		MugHolder.SetActive(false);
	}

	void OnTriggerEnter(Collider other) {
		if (!isHolding) {
			if (other.gameObject.name != "Player") {
				MugHolder.SetActive(true);
				inTrigger = true;
			}
		}


	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.name != "Player") {
			MugHolder.SetActive(false);
			inTrigger = false;
			isHolding = false;
			mug = null;
		}
		
	}

	public bool holding() {
		return isHolding;
	}
	
	public void setHolding(bool holding) {
		isHolding = holding;
	}

	public bool trigger() {
		return inTrigger;
	}

	public void setMug(GameObject mug) {
		this.mug = mug;
	}

	public GameObject getMug() {
		if (isHolding) {
			return mug;
		}
		return null;
		
	}
}
