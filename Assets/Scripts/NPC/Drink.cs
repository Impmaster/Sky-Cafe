using UnityEngine;
using System.Collections;

public class Drink : MonoBehaviour {

	public GameObject coaster;

	public OrderDrink order;
	
	public float drinkTime = 5;

	holdMug mugHolder;

	mugInventory mug;

	public int happiness;

	public bool finishedDrinking;
	
	IEnumerator wait() {
		yield return new WaitForSeconds(drinkTime);

		if (mug.currState == "Hot") {
			happiness++;
		} else if (mug.currState == "Warm") {
			//Do nothing, it's fine.
		} else if (mug.currState == "Cold") {
			happiness--;
		}

		int mugCof = 0;
		int mugCre = 0;
		int mugMil = 0;
		int mugSug = 0;

		int myCof = 0;
		int myCre = 0;
		int myMil = 0;
		int mySug = 0;

		for (int x = 0; x < mug.ingredients.Length; x++) {
			if (mug.ingredients[x] == "Coffee") {
				mugCof++;
			} else if (mug.ingredients[x] == "Cream") {
				mugCre++;
			} else if (mug.ingredients[x] == "Milk") {
				mugMil++; 
			} else if (mug.ingredients[x] == "Sugar") {
				mugSug++;
			}
		}
		for (int x = 0; x < order.ingredients.Length; x++) {
			if (order.ingredients[x] == "Coffee") {
				myCof++;
			} else if (order.ingredients[x] == "Cream") {
				myCre++;
			} else if (order.ingredients[x] == "Milk") {
				myMil++; 
			} else if (order.ingredients[x] == "Sugar") {
				mySug++;
			}

		}
		//If it's the wrong order happiness goes down.
		if (mugCof != myCof || mugCre != myCre || mugMil != myMil || mugSug != mySug) {
			happiness--;
		}

		finishedDrinking = true;
	}

	void drink() {

		mugHolder = coaster.GetComponent<holdMug>();
		mug = mugHolder.mug.GetComponent<mugInventory>();

		StartCoroutine(wait());
		
	}
}
