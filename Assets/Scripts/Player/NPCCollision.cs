using UnityEngine;
using System.Collections;

public class NPCCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.IgnoreLayerCollision(10, 14);
		
	}
	
}
