using UnityEngine;
using System.Collections;

public class mugInventory : MonoBehaviour {

	public string[] ingredients;
	public int numberOfIngredients = 4;

	public float hotTime = 0f;

	public float warmTime = 30f;
	public float coldTime = 45f;

	private float startTime;
	public float timeSpent;
	public bool isFull;

	public string currState = "Cold";

	public Material hotState;
	public Material warmState;
	public Material coldState;

	private int currNum = 0;

	void Start() {
		ingredients = new string[numberOfIngredients];
	}

	//Resets the mug
	public void Finish() {
		for (int x = 0; x < numberOfIngredients; x++) {
			ingredients[x] = null;
			
		}
		timeSpent = 0;
		isFull = false;
		currState = "Cold";
		currNum = 0;
	}

	public void addIngredient(string name) {
		if (currNum < numberOfIngredients) {
			ingredients[currNum] = name;
			currNum++;
		}

		if (currNum == numberOfIngredients) {
			isFull = true;
		}

	}

	void Update() {
		if (isFull) {
			if (startTime == 0) {
				startTime = Time.time;
			}

			timeSpent = Time.time - startTime;

			if (timeSpent < warmTime) {
				currState = "Hot";
				gameObject.GetComponentInChildren<Renderer>().material = hotState;
			}

			if (timeSpent > warmTime) {
				currState = "Warm";
				gameObject.GetComponentInChildren<Renderer>().material = warmState;
			}

			if (timeSpent > coldTime) {
				currState = "Cold";
				gameObject.GetComponentInChildren<Renderer>().material = coldState;
			}
		}

	}
}
