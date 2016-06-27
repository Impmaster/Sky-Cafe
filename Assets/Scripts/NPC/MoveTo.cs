// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	[SerializeField]
	private Transform dest;
	void setDestination (GameObject goal) {
		dest = goal.transform ;
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = dest.position; 
	}

	public Transform getLocation() {
		return dest;
	}
}