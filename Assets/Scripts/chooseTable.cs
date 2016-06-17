using UnityEngine;
using System.Collections;


public class chooseTable : MonoBehaviour {
	[SerializeField]
	private GameObject[] tables;
	private int[] taken;

	// Use this for initialization
	void Start () {
		taken = new int[tables.Length];
		for (int x = 0; x < tables.Length; x++) {
			taken[x] = 0;
		}
	}
	
	public GameObject getTable() {
		int table = Random.Range(0, tables.Length-1);
		while (taken[table] == 1) {
			table += 1;
			if (table > tables.Length - 1) {
				table = 0;
			}
		}
		taken[table] = 1;
		return tables[table];
	}
}
