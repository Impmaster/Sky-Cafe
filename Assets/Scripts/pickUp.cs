using UnityEngine;

//MADE BY ALIX OLLIVIER

public class pickUp : MonoBehaviour {

	public Camera cam;

	public int distanceFromObject = 5;

	private bool isHolding;
	private GameObject currentObject;

	//When the items Layer is created, it has to be changed here.
	public int itemsLayer = 8;

	public holdMug machineScript;

	// Use this for initialization
	void Start () {
		//Supplies a bitMask for the Raycast	
		itemsLayer = 1 << itemsLayer;
	}
	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

		if (!isHolding) {
			//Casts a ray only on the "item" layer
			if (Physics.Raycast(ray, out hit, distanceFromObject, itemsLayer)) {
				

				//Chooses to pick up an object
				if (Input.GetKeyDown(KeyCode.E)) {

					//If not holding anything, pick it up
					if (!isHolding) {
						hit.transform.SetParent(gameObject.transform);
						hit.transform.gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
						currentObject = hit.transform.gameObject;
						isHolding = true;
						if (machineScript.trigger()) {
							machineScript.setHolding(false);
						}
					} else {
						//Do a sound effect or something
					}
				}
				
			}
		} else {

			if (Input.GetKeyDown(KeyCode.E)) {
				//Put the mug on the machine
				if (machineScript.trigger()) {
					currentObject.transform.SetParent(null);
					currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
					currentObject.transform.position = machineScript.MugHolder.transform.position;
					isHolding = false;
					machineScript.setHolding(true);
					machineScript.setMug(currentObject);
				} else {
					//Drop the mug
					currentObject.transform.SetParent(null);
					currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
					isHolding = false;
				}

			}
			
		}

		
	}



}
