using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class DataController : MonoBehaviour {

#region Singleton
	public static DataController instance = null;
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

	private int loadedBest = 1;


    void Start() {
        LoadPlayerProgress();
    }

    public void SubmitNewPlayerScore(int newScore) {
        if(newScore > loadedBest) {
			loadedBest = newScore;
            SavePlayerProgress();
        }
    }

    private void LoadPlayerProgress() {
        if(PlayerPrefs.HasKey("bestLevel")) {
            LevelController.instance.bestLevel = PlayerPrefs.GetInt("bestLevel");
			Debug.Log("Best level:  " + LevelController.instance.bestLevel);
        }
		else
			Debug.Log("Nothing to load");
    }

   	private void SavePlayerProgress() {
    	PlayerPrefs.SetInt("bestLevel", LevelController.instance.bestLevel);
		Debug.Log("Saved best level:  " + LevelController.instance.bestLevel);
    }
}