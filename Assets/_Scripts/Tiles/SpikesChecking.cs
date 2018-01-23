using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikesChecking : MonoBehaviour {

	private Text winText;


	void Start() {
		winText = GameObject.Find("WinText").GetComponent<Text>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			winText.text = "YOU DIED";
			winText.enabled = true;
			Time.timeScale = 0;
		}
	}
}
