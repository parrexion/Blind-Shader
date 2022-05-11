using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	public Canvas mainMenuCanvas;
	public Canvas levelSelectCanvas;

	public GameObject mainButtonGroup;
	public Button[] levelButtons;

	public AudioClip selectSfx;
	public AudioClip backSfx;
	public AudioClip exitGameSfx;
	

	private void Start () {
		mainMenuCanvas.enabled = true;
		levelSelectCanvas.enabled = false;
	}
	
	public void GoToLevelSelect() {
		ActivateLevels();
		mainMenuCanvas.enabled = false;
		levelSelectCanvas.enabled = true;
		AudioController.instance.PlaySfx(selectSfx);
	}

	public void GoToMainMenu() {
		mainMenuCanvas.enabled = true;
		levelSelectCanvas.enabled = false;
		AudioController.instance.PlaySfx(backSfx);
	}

	public void GoToSpecificLevel(int level) {
		AudioController.instance.PlaySfx(selectSfx);
		LevelController.instance.currentLevel = level;
		LevelController.instance.RestartLevel();
	}

	public void ExitGame() {
		mainButtonGroup.SetActive(false);
		AudioController.instance.PlaySfx(exitGameSfx);
		StartCoroutine(DelayedExit());
	}

	private IEnumerator DelayedExit() {
		yield return new WaitForSeconds(0.5f);
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}

	private void ActivateLevels() {
		for (int i = 0; i < levelButtons.Length; i++) {
			levelButtons[i].interactable = (i < LevelController.instance.bestLevel);
		}
	}
}
