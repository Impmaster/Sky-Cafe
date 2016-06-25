using UnityEngine;

//MADE BY ALIX OLLIVIER

public class pickUp : MonoBehaviour {

	public Camera cam;
	public LookAt lookAt;
	public holdMug machineScript;
	//When the items Layer is created, it has to be changed here.
	public int itemsLayer = 8;
	private bool isHolding;
	private GameObject currentObject;



	// Use this for initialization
	void Start () {
		//Supplies a bitMask for the Raycast	
		itemsLayer = 1 << itemsLayer;
	}
	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;

		if (!isHolding) {
			//Casts a ray only on the "item" layer
			if (lookAt.inFront(out hit, itemsLayer)) {
				//Chooses to pick up an object
				if (Input.GetKeyDown(KeyCode.E)) {
					//Set the object to be linked to the player
					hit.transform.SetParent(gameObject.transform);
					//Turn off the physics
					hit.transform.gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
					//Start holding the object
					currentObject = hit.transform.gameObject;
					isHolding = true;
					
					//If the cup was in the machine, tell the machine it's now empty
					if (machineScript.trigger()) {
						machineScript.setHolding(false);
					} 
				}
				
			}
		} else { //Holding something

			if (Input.GetKeyDown(KeyCode.E)) {
				//Put the mug on the machine
				if (machineScript.trigger()) {

					//Set it in the machine
					currentObject.transform.SetParent(null);
					currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
					currentObject.transform.position = machineScript.MugHolder.transform.position;
					//Tell the player it's now empty and the machine is full
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
