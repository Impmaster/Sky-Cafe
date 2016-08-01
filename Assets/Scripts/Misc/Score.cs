using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {


	public Text text;

	public Text isHotText;

	public Text rightIngredientsText;

	public int score;

	public int HotPoints = 5;
	public int WarmPoints = 0;

	public int ColdPoints = -5;

	public int rightIngredientsPoints = 5;
	public int wrongIngredientsPoints = -5;

	public void GetQuality(string isHot, bool rightIngredients) {

		
		if (isHot == "Hot") {
			score += HotPoints;
			isHotText.text = "Mug was " + isHot + ". +" + HotPoints + " points.";
		} else if (isHot == "Warm") {
			score += WarmPoints;
			isHotText.text = "Mug was " + isHot + ". +" + WarmPoints + " points.";
		} else if (isHot == "Cold") {
			score += ColdPoints;
			isHotText.text = "Mug was " + isHot + ". +" + ColdPoints + " points.";
		}

		if (rightIngredients) {
			rightIngredientsText.text = "Perfect Blend. +" + rightIngredientsPoints + " points.";
		} else {
			rightIngredientsText.text = "Wrong Coffee Ingredients! +" + wrongIngredientsPoints + " points.";
		}

		if (rightIngredients) {
			score += rightIngredientsPoints;
		} else {
			score += wrongIngredientsPoints;
		}

		text.text = score.ToString();
	}
}
