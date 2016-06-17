using UnityEngine;

//MADE BY ALIX OLLIVIER

public class pickUp : MonoBehaviour {

	public Camera cam;

	public int distanceFromObject = 5;

	//When the items Layer is created, it has to be changed here.
	public int itemsLayer = 8;

	// Use this for initialization
	void Start () {
			itemsLayer = 1 << itemsLayer;
	}
	
	// Update is called once per frame
	void Update () {
	    RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

		//Casts a ray only on the "item" layer
        if (Physics.Raycast(ray, out hit, distanceFromObject, itemsLayer)) {
			if (Input.GetKeyDown(KeyCode.E)) {
				hit.transform.gameObject.SetActive(false);
			}
			
		}
	}



}
