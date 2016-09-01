using UnityEngine;
using System.Collections;

public class buttonActivate : MonoBehaviour {


	public GameObject liquid;
	private AudioSource src;
	public holdMug machineScript;
	public LookAt lookAt;
	public string type;
	public int distanceFromObject = 5;
	public float pushDistance = 0.01f;
	private mugInventory mugHolder;

	private Vector3 pushedLocation;
	private Vector3 originalLocation;

	void Start() {
		originalLocation = transform.localPosition;
		pushedLocation = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + pushDistance);
		liquid.SetActive(false);
		src = GetComponent<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;

		//If the player is looking at the button
        if (lookAt.inFront(out hit)) {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (hit.transform.gameObject == gameObject) {
					Push();
				}
			} 
			
			if (!Input.GetKey(KeyCode.E)) {
				Undo();
			}


		}
		
	}


	void Push() {
		transform.localPosition = pushedLocation;
		if (machineScript.holding()) {
			mugHolder = machineScript.getMug().GetComponent<mugInventory>();
			mugHolder.addIngredient(type);
			liquid.SetActive(true);
			src.Play();
		}
	}

	void Undo() {
		transform.localPosition = originalLocation;
		liquid.SetActive(false);
	}

}
