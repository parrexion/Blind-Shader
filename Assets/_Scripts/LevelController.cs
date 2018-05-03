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

	public int bestLevel = 1;
	public int currentLevel = 0;


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
		bestLevel = Mathf.Max(bestLevel, currentLevel);
		DataController.instance.SubmitNewPlayerScore(bestLevel);
		RestartLevel();
	}
}
