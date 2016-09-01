using UnityEngine;
using System.Collections;


public class chooseTable : MonoBehaviour {
	[SerializeField]
	private GameObject[] tables;
	private int[] taken;

	public GameObject platforms;

	public GameObject coaster;

	// Use this for initialization
	void Start () {
		taken = new int[tables.Length];
		for (int x = 0; x < tables.Length; x++) {
			taken[x] = 0;
			tables[x] = platforms.transform.GetChild(x).gameObject;
		}
	}
	
	public GameObject getTable() {
		int tries = 0;
		int table = Random.Range(0, tables.Length-1);
		while (taken[table] == 1) {
			table += 1;
			tries++;
			if (table > tables.Length - 1) {
				table = 0;
			}
			if (tries > tables.Length) {
				return null;
			}
		}
		taken[table] = 1;
		return tables[table];
	}

	public void emptyTable(GameObject table) {
		if (table != null) {
			for (int x = 0; x < tables.Length; x++) {
				if (tables[x] == table) {
					taken[x] = 0;
				}
			}
		}
	}

}
