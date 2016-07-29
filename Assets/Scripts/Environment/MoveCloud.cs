using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {

	public float xSpeed = 1;
	public float ySpeed = 0;
	public float zSpeed = 0;

	public float distance = 50;

	private Vector3 origin;

	void Start() {
		origin = transform.position;

	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(origin, transform.position) < distance) {
			transform.position = new Vector3(transform.position.x + xSpeed*Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z + zSpeed * Time.deltaTime);
		} else {
			
		}
	}
}
