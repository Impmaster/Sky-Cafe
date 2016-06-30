using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrderDrink : MonoBehaviour {

	
	public Canvas ui;

	//Needs to be a panel on the Canvas
	//A GridLayoutGroup on the Panel. Should be a component that is attached to inventory above.
	public GridLayoutGroup grid;

	//An array where you put all the images for the items you pick up. 
	//All images have to have exactly the same name as the objects they correspond to. A "Key" GameObject needs a "Key.png" image.
	Image[] images;
	public string[] ingredients;

	public int npcLayer = 10;

	public IngredientsArray ingredientsArray;

	[SerializeField]
	private LookAt lookAt;

	bool isWaiting;
	bool finished;

	// Use this for initialization
	void Start () {
		ui.enabled = false;
		images = ingredientsArray.getIngredients();

		//Supplies a bitMask for the Raycast	
		npcLayer = 1 << npcLayer;
	}
	
	void Order() {
		for (int x = 0; x < ingredients.Length; x++) {
			for (int y = 0; y < ingredients.Length; y++) {
				if (ingredients[x] == images[y].name) {
					Image image = Instantiate(images[y]);
					image.transform.SetParent(grid.transform);
					//Make the image face the right way
					image.transform.rotation = grid.transform.rotation;
					image.transform.localPosition = new Vector3(0,0,0);
					image.transform.localScale = new Vector3(1,1,1);
				}
			}
			
			
			
		}

		isWaiting = true;
		ui.enabled = true;
	}

	void Update() {
		if (isWaiting) {
			RaycastHit hit;

			if (lookAt.inFront(out hit, npcLayer)) {
				if (hit.transform.gameObject == gameObject) {
					if (Input.GetKey(KeyCode.E)) {
						isWaiting = false;
						finished = true;
					}

				}
			}
		}
	}

	public bool getFinished() {
		return finished;
	}

	void WalkToTable() {
		ui.enabled = false;
	}

}
