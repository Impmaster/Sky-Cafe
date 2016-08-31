using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

	public float rotateSpeed = 5;

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
	}
}
