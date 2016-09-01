using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

	public Text text;

	private string endScore;

	

	public void showScore(int score) {
		if (score <= 50 ) {
			endScore = "You had an unlucky day. Day Over.";
		} else if (score <= 70) {
			endScore = "You missed a few orders, but overall you're doing pretty well. Day Over.";
		} else if (score <= 100) {
			endScore = "What a great day! Day Over.";
		} else {
			endScore = "You were flawless out there. Day Over.";
		}

		text.text = endScore;	

	}

}
