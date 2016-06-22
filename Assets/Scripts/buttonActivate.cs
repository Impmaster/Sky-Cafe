using UnityEngine;
using System.Collections;

public class buttonActivate : MonoBehaviour {


	public Camera cam;
	public holdMug machineScript;
	public string type;

	private mugInventory mugHolder;

	public int distanceFromObject = 5;

	public float pushDistance = 0.01f;

	private Vector3 pushedLocation;
	private Vector3 originalLocation;

	void Start() {
		originalLocation = transform.localPosition;
		pushedLocation = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + pushDistance);
	}

	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

		//If the player is looking at the button
        if (Physics.Raycast(ray, out hit, distanceFromObject)) {
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
		mugHolder = machineScript.getMug().GetComponent<mugInventory>();
		mugHolder.addIngredient(type);
	}

	void Undo() {
		transform.localPosition = originalLocation;
	}

}
