using UnityEngine;
using System.Collections;

public class Sit : MonoBehaviour {

	public GameObject coaster;

	holdMug mugHolder;

	public void SetMugHolder() {
		mugHolder = coaster.GetComponent<holdMug>();

	}


	//If player has put down the drink
	public bool GotDrink() {
		if (mugHolder.holding()) {
			return true;
		}

 		else return false;
	}
}
