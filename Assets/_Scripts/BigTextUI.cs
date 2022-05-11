using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigTextUI : MonoBehaviour {

	public GameObject background;
	public GameObject winText;
	public GameObject deathText;
	public Image keyImage;
	public Button fireButton;

	[Header("Audio")]
	public AudioClip victorySfx;
	public AudioClip deathSfx;


	private void Start() {
		background.SetActive(false);
		winText.SetActive(false);
		deathText.SetActive(false);

		UpdateKey(false);
		PlayerController player = FindObjectOfType<PlayerController>();
		if(player)
			player.onKeyUpdated += UpdateKey;
	}

	public void ShowVictory() {
		AudioController.instance.PlaySfx(victorySfx);
		background.SetActive(true);
		winText.SetActive(true);
	}

	public void ShowDeath() {
		AudioController.instance.PlaySfx(deathSfx);
		background.SetActive(true);
		deathText.SetActive(true);
	}

	private void UpdateKey(bool hasKey) {
		keyImage.enabled = hasKey;
	}
}
