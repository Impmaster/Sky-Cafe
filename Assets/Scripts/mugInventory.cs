using UnityEngine;
using System.Collections;

public class mugInventory : MonoBehaviour {

	public string[] ingredients;
	public int numberOfIngredients = 4;

	private int currNum = 0;

	void Start() {
		ingredients = new string[numberOfIngredients];
	}

	public void addIngredient(string name) {
		if (currNum < numberOfIngredients) {
			ingredients[currNum] = name;
			currNum++;
		}

	}
}
