using UnityEngine;
using System.Collections;

public class DisableMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnApplicationFocus() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}



}
