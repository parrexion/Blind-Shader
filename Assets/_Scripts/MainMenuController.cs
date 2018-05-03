using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public Canvas mainMenuCanvas;
	public Canvas levelSelectCanvas;

	public Button[] levelButtons;
	

	// Use this for initialization
	void Start () {
		GoToMainMenu();
	}
	
	public void GoToLevelSelect() {
		ActivateLevels();
		mainMenuCanvas.enabled = false;
		levelSelectCanvas.enabled = true;
	}

	public void GoToMainMenu() {
		mainMenuCanvas.enabled = true;
		levelSelectCanvas.enabled = false;
	}

	public void GoToSpecificLevel(int level) {
		LevelController.instance.currentLevel = level;
		LevelController.instance.RestartLevel();
	}

	public void ExitGame() {
		Application.Quit();
	}

	void ActivateLevels() {
		for (int i = 0; i < levelButtons.Length; i++) {
			levelButtons[i].interactable = (i < LevelController.instance.bestLevel);
		}
	}
}
