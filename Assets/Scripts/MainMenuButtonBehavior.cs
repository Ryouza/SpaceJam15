using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuButtonBehavior : MonoBehaviour {

	Canvas canvas;

	void Start () {
		print ("Started");

		GameObject optionCanvas = GameObject.Find ("OptionCanvas");
		//optionCanvas.SetActive (false);
		canvas = optionCanvas.GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	// Update is called once per frame
	//void Update () {
	//
	//	GameObject optionCanvas = GameObject.Find ("OptionCanvas");
	//	optionCanvas.SetActive (true);
	//}

	public void QuitGame () {
		Debug.Log ("Game is Exiting...");
		Application.Quit ();
	}

	public void StartGame (string level) {
		//Application.LoadLevel ("TestLv1"); // if didn't have parameter
		Application.LoadLevel (level);
	}

	public void GameOptions () {
		GameObject mainCanvas = GameObject.Find ("MainCanvas");
		//mainCanvas.SetActive (false);
		canvas = mainCanvas.GetComponent<Canvas> ();
		canvas.enabled = false;

		print ("GOOOOOOOOO");

		GameObject optionCanvas = GameObject.Find ("OptionCanvas");
		//optionCanvas.SetActive (true);
		canvas = optionCanvas.GetComponent<Canvas> ();
		canvas.enabled = true;
	}

	public void BackToMenu() {
		GameObject optionCanvas = GameObject.Find ("OptionCanvas");
		canvas = optionCanvas.GetComponent<Canvas> ();
		canvas.enabled = false;

		GameObject mainCanvas = GameObject.Find ("MainCanvas");
		canvas = mainCanvas.GetComponent<Canvas> ();
		canvas.enabled = true;
	}

	public void RestartLevel() {
		//reloads the current level.
		Application.LoadLevel (Application.loadedLevel);
	}

	public void RestartGame() {
		//Loads the MainMenu.
		Application.LoadLevel ("MainMenu");
	}



}
