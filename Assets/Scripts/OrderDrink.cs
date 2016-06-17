using UnityEngine;
using System.Collections;

public class OrderDrink : MonoBehaviour {

	[SerializeField]
	Canvas ui;

	// Use this for initialization
	void Start () {
		ui.enabled = false;
	}
	
	void Order() {
		ui.enabled = true;
	}

	void WalkToTable() {
		ui.enabled = false;
	}

}
