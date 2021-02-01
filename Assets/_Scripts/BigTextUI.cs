using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigTextUI : MonoBehaviour {

	public GameObject background;
	public GameObject winText;
	public GameObject deathText;


	private void Start() {
		background.SetActive(false);
		winText.SetActive(false);
		deathText.SetActive(false);
	}

	public void ShowVictory() {
		background.SetActive(true);
		winText.SetActive(true);
	}

	public void ShowDeath() {
		background.SetActive(true);
		deathText.SetActive(true);
	}
}
