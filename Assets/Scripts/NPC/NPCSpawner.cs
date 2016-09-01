using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour {

	public GameObject[] npcs;
	public float timeBetween = 15f;

	public float startTime = 60f;
	private int currentNpc = 0;

	public BarLine lastBarPosition;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < npcs.Length; x++) {
			npcs[x].SetActive(false);
		}
		StartCoroutine(waitForSpawn());
	}

	IEnumerator waitForSpawn() {

		yield return new WaitForSeconds(startTime);
		StartCoroutine(Spawn());
	}


	IEnumerator Spawn() {
		while (!lastBarPosition.isEmpty) {
			yield return new WaitForSeconds(timeBetween);
		}
		if (currentNpc < npcs.Length) {
			npcs[currentNpc].SetActive(true);
			currentNpc++;
		}
		 yield return new WaitForSeconds(timeBetween);
		 StartCoroutine(Spawn());
	}
	
	
}
