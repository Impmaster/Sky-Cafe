using UnityEngine;

//MADE BY ALIX OLLIVIER

public class pickUp : MonoBehaviour {

	public Camera cam;
	public LookAt lookAt;
	public holdMug holdScript;
	//When the items Layer is created, it has to be changed here.
	public int itemsLayer = 8;
	public int containersLayer = 9;
	public GameObject holder;
	private bool isHolding;
	private GameObject currentObject;



	// Use this for initialization
	void Start () {
		//Supplies a bitMask for the Raycast	
		itemsLayer = 1 << itemsLayer;
		containersLayer = 1 << containersLayer;
	}
	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;

		//Chooses the proper container
		if (lookAt.inFront(out hit, containersLayer)) {
			holdScript = hit.collider.transform.gameObject.GetComponent<holdMug>();
		}

		if (!isHolding) {
			//Casts a ray only on the "item" layer
			if (lookAt.inFront(out hit, itemsLayer)) {
				//Chooses to pick up an object
				if (Input.GetKeyDown(KeyCode.E)) {
					//Set the object to be linked to the player
					hit.collider.transform.SetParent(holder.transform);
					hit.collider.transform.position = holder.transform.position;
					hit.collider.transform.rotation = holder.transform.rotation;
					//Turn off the physics
					hit.collider.transform.gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = true;
					//Start holding the object
					currentObject = hit.collider.transform.gameObject;
					isHolding = true;
					
					//If the cup was in the machine, tell the machine it's now empty
					if (holdScript != null) {
						if (holdScript.trigger() && holdScript.holding()) {
							holdScript.setHolding(false);
						} 

					}
				}
				
			} else {
				//Sound effect or something

			}
		} else { //Holding something

			if (Input.GetKeyDown(KeyCode.E)) {
				//Put the mug on the machine
				if (holdScript != null) {
					if (holdScript.trigger() && holdScript.holding() == false) {

						if (currentObject.tag == "Mug") {
							//Set it in the machine
							currentObject.transform.SetParent(null);
							//currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
							currentObject.transform.position = holdScript.MugHolder.transform.position;
							currentObject.transform.rotation = holdScript.MugHolder.transform.rotation;
							//Tell the player it's now empty and the machine is full
							isHolding = false;
							holdScript.setHolding(true);
							holdScript.setMug(currentObject);
						}
					} else {
						//Drop the mug
						currentObject.transform.SetParent(null);
						currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
						isHolding = false;
					}
					
				}  else {
					//Drop the mug
					currentObject.transform.SetParent(null);
					currentObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
					isHolding = false;
				}

			}
			
		}

		
	}



}
