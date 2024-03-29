﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller for pausing the game and showing the pause menu.
/// </summary>
public class VictoryController : MonoBehaviour {

	public AudioClip victorySfx;


	private void Start() {
		if (victorySfx)
			AudioController.instance.PlaySfx(victorySfx);
	}

	/// <summary>
	/// Returns to the main menu.
	/// </summary>
	public void ReturnToMain() {
		SceneManager.LoadScene(0);
	}
}
