using UnityEngine;
using UnityEngine.SceneManagement;


public class changeLevel : MonoBehaviour {
	public void change() {
		SceneManager.LoadScene(1);
	}

	public void Quit() {
		Application.Quit();
	}
}
