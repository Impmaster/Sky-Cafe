using UnityEngine;
using System.Collections;

public class MoveCloud : MonoBehaviour {

	public float xSpeed = 1f;
	public float ySpeed = 1f;
	public float zSpeed = 1f;
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x + xSpeed*Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z + zSpeed * Time.deltaTime);
	}
}
