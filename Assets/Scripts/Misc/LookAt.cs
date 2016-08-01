using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Camera cam;

	public int distanceFromObject = 5;

	//Returns if the object is in front
	public bool inFront(out RaycastHit hit) {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out hit, distanceFromObject)) {
			return true;
		} else {
			return false;
		}

	}

	//Only targets certain layers
	public bool inFront(out RaycastHit hit, int layerMask) {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out hit, distanceFromObject, layerMask)) {
			return true;
		} else {
			return false;
		}

	}

	//Specifies a distance
	public bool inFront(out RaycastHit hit, int layerMask, float distanceFromObject) {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out hit, distanceFromObject, layerMask)) {
			return true;
		} else {
			return false;
		}

	}

	//Specifies a distance
	public bool inFront(out RaycastHit hit, int layerMask, float distanceFromObject, GameObject target) {
		//Makes a ray in the right direction
        Ray ray = new Ray(cam.transform.position, target.transform.position-cam.transform.position);

		//Actually casts it in a certain direction
		if (Physics.Raycast(ray, out hit, distanceFromObject, layerMask, QueryTriggerInteraction.Ignore)) {
			return true;
		} else {
			return false;
		}

	}


	


	
}
