using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverButtonBehavior : MonoBehaviour {

	public void RestartLevel() {
		//reloads the current level.
		Application.LoadLevel (Application.loadedLevel);
	}

	public void RestartGame() {
		//Loads the MainMenu.
		Application.LoadLevel ("MainMenu");
	}



}
