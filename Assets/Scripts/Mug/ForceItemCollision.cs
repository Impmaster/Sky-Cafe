using UnityEngine;
using System.Collections;

public class ForceItemCollision : MonoBehaviour {

	//This class pushes the item outside of walls

	public GameObject holder;

	public bool beingHeld;

	private bool updatePos;

	private Collision collision;

	private Collider col;

	void Start() {
		col = GetComponent<Collider>();
	}


	void Update() {

		if (col.attachedRigidbody.isKinematic) {
			beingHeld = true;
		} else beingHeld = false;







		if (beingHeld) {
			if (updatePos) {
				ContactPoint contact = collision.contacts[0];

				float distanceInWall = Vector3.Distance(contact.point, col.ClosestPointOnBounds(contact.point));

				Debug.DrawLine(contact.point, col.ClosestPointOnBounds(contact.point), Color.blue, 1);

				//print (distanceInWall);

				transform.position += contact.normal * distanceInWall;

				updatePos = false;
			} else {
				
		
			}
		}
	}

	
	void OnCollisionEnter(Collision collision) {

		if (beingHeld) {
			print ("YESY");
			this.collision = collision;
			updatePos = true;

		}

	}

}
