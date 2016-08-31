using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrderDrink : MonoBehaviour {

	public string realName = "Caesar";

	public string starbucksName = "Seezar";
	
	public Canvas ui;

	//Name placed over NPC head
	public Text NPCname;


	public Text text;

	//Needs to be a panel on the Canvas
	//A GridLayoutGroup on the Panel. Should be a component that is attached to inventory above.
	public GridLayoutGroup grid;

	public GameObject OrderPrefab;

	//On the side for the notepad
	public GridLayoutGroup orderList;

	//For the ingredients in the order
	private GridLayoutGroup orderGroup;


	//An array where you put all the images for the items you pick up. 
	//All images have to have exactly the same name as the objects they correspond to. A "Key" GameObject needs a "Key.png" image.
	Image[] images;
	public string[] ingredients;

	public int npcLayer = 10;

	public IngredientsArray ingredientsArray;

	[SerializeField]
	private LookAt lookAt;

	[SerializeField]
	bool isWaiting;
	bool finished;

	GameObject currentOrder;

	[SerializeField]
	private string tip = "Press E to take order.";

	// Use this for initialization
	void Start () {
		ui.enabled = false;
		images = ingredientsArray.getIngredients();
		NPCname.text = realName;

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

	public void addOrderToList() {



		currentOrder = (GameObject)Instantiate(OrderPrefab, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));

		currentOrder.transform.SetParent(orderList.transform);
		currentOrder.transform.rotation = orderList.transform.rotation;
		currentOrder.transform.localPosition = new Vector3(0,0,0);
		currentOrder.transform.localScale = new Vector3(1,1,1);
		orderGroup = currentOrder.GetComponentInChildren<GridLayoutGroup>();

		GameObject CoffeeVar = currentOrder.transform.Find("Coffee/CoffeeVar").gameObject;
		GameObject CreamVar = currentOrder.transform.Find("Cream/CreamVar").gameObject;
		GameObject MilkVar = currentOrder.transform.Find("Milk/MilkVar").gameObject;
		GameObject SugarVar = currentOrder.transform.Find("Sugar/SugarVar").gameObject;

		int numCof = 0;
		int numCream = 0;
		int numMilk = 0;
		int numSug = 0;
		
		for (int x = 0; x < ingredients.Length; x++) {
			for (int y = 0; y < ingredients.Length; y++) {
				if (ingredients[x] == images[y].name) {
					if (images[y].name == "Coffee") {
						numCof++;
					} else if (images[y].name == "Cream") {
						numCream++;
					} else if (images[y].name == "Milk") {
						numMilk++;
					} else if (images[y].name == "Sugar") {
						numSug++;
					}

				}
			}
			
			
			
		}
		
		CoffeeVar.GetComponent<Text>().text = numCof.ToString();
		CreamVar.GetComponent<Text>().text = numCream.ToString();
		MilkVar.GetComponent<Text>().text = numMilk.ToString();
		SugarVar.GetComponent<Text>().text = numSug.ToString();
	} 

	public void removeOrder() {
		Destroy(currentOrder);
	}

	void Update() {
		if (isWaiting) {
			RaycastHit hit;

			if (lookAt.inFront(out hit, npcLayer)) {
				if (hit.transform.gameObject == gameObject) {
					text.text = tip;
				}
				if (hit.transform.gameObject == gameObject) {
					
					if (Input.GetKey(KeyCode.E)) {
						isWaiting = false;
						finished = true;
						text.text = "";
					}

				}
			} else {
				if (text.text == tip) {
					text.text = "";
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
