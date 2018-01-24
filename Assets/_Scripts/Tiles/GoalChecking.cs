using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalChecking : MonoBehaviour {

	private Text winText;


	void Start() {
		winText = GameObject.Find("WinText").GetComponent<Text>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (other.GetComponent<PlayerController>().hasKey) {
				winText.enabled = true;
				PlayerController.dead = true;
				StartCoroutine(GoalReached());
			}
		}
	}

	IEnumerator GoalReached() {

		yield return new WaitForSeconds(2f);

		LevelController.instance.NextLevel();

		yield break;
	}
}
