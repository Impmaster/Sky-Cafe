using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour {

	public GameObject[] npcs;
	public float timeBetween = 15f;
	private int currentNpc = 0;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < npcs.Length; x++) {
			npcs[x].SetActive(false);
		}
		StartCoroutine(Spawn());
	}

	void Update() {
		//StartCoroutine(Spawn());
	}


	IEnumerator Spawn() {
		if (currentNpc < npcs.Length) {
			npcs[currentNpc].SetActive(true);
			currentNpc++;
		}
		 yield return new WaitForSeconds(timeBetween);
		 StartCoroutine(Spawn());
	}
	
	
}
