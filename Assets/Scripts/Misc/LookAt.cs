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

	//Returns if the object is in front
	public bool inFront(out RaycastHit hit, int layerMask) {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		if (Physics.Raycast(ray, out hit, distanceFromObject, layerMask)) {
			return true;
		} else {
			return false;
		}

	}


	


	
}
