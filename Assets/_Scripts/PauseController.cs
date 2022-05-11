using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller for pausing the game and showing the pause menu.
/// </summary>
public class PauseController : MonoBehaviour {

	public Canvas pauseCanvas;
	public AudioClip showPauseSfx;
	public AudioClip hidePauseSfx;
	public AudioClip clickSfx;

	private bool isPaused;
	private float oldVolume;


	private void Start () {
		isPaused = false;
		pauseCanvas.enabled = isPaused;
	}

	private void Update () {
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
		if(isPaused) {
			oldVolume = AudioController.instance.musicVolume;
			AudioController.instance.SetMusicVolume(0f);
			AudioController.instance.PlaySfx(showPauseSfx);
		} 
		else {
			AudioController.instance.SetMusicVolume(oldVolume);
			AudioController.instance.PlaySfx(hidePauseSfx);
		}
	}

	/// <summary>
	/// Returns to the main menu.
	/// </summary>
	public void ReturnToMain() {
		Time.timeScale = 1;
		AudioController.instance.PlaySfx(clickSfx);
		SceneManager.LoadScene(0);
	}
}
