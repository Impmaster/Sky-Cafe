using UnityEngine;
using System.Collections;

public class WaitForEnd : MonoBehaviour {

	public float numberDone;

	public float numNPCs = 16;

	PlayMakerFSM playmakerFSM;

	void Start() {
		playmakerFSM = GetComponent<PlayMakerFSM>();
	}

	void OnTriggerEnter() {
		numberDone++;
	}

	void Update() {
		if (numNPCs == numberDone) {
			playmakerFSM.SendEvent("End Game");
		}
	}
}
