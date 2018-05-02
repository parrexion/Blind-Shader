using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller for pausing the game and showing the pause menu.
/// </summary>
public class PauseController : MonoBehaviour {

	public Canvas pauseCanvas;

	bool isPaused;


	// Use this for initialization
	void Start () {
		isPaused = false;
		pauseCanvas.enabled = isPaused;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			TogglePause();
		}
	}

	/// <summary>
	/// Toggles the pause menu and the game speed.
	/// </summary>
	public void TogglePause() {
		isPaused = !isPaused;
		pauseCanvas.enabled = isPaused;

		Time.timeScale = (isPaused) ? 0 : 1;
	}

	/// <summary>
	/// Returns to the main menu.
	/// </summary>
	public void ReturnToMain() {
		Debug.Log("asdjsldjasljdf");
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
}
