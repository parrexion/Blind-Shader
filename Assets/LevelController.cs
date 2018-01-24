using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

#region Singleton
	public static LevelController instance = null;
	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
	}
#endregion

	int currentLevel = 0;


	void Update() {
		if (Input.GetKeyDown(KeyCode.L))
			NextLevel();
	}

	public void RestartLevel() {
		PlayerController.dead = false;
		SceneManager.LoadScene(currentLevel);
	}

	public void NextLevel() {
		currentLevel++;
		RestartLevel();
	}
}
