using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalChecking : MonoBehaviour {

	private BigTextUI winText;


	void Start() {
		winText = FindObjectOfType<BigTextUI>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (other.GetComponent<PlayerController>().hasKey) {
				winText.ShowVictory();
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
