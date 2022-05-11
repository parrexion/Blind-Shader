using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

#region Singleton
	public static LevelController instance = null;
	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		}
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
#endregion

	public int bestLevel = 1;
	public int currentLevel = 0;
	public AudioClip ambienceTrack;


	private void Start() {
		if(ambienceTrack)
			AudioController.instance.PlayAmbience(ambienceTrack);
	}

	private void Update() {
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.L))
			NextLevel();
#endif
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
