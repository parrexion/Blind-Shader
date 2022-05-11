using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecking : MonoBehaviour {

	private BigTextUI winText;


	private void Start() {
		winText = FindObjectOfType<BigTextUI>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			if (other.GetComponent<PlayerController>().hasKey) {
				winText.ShowVictory();
				PlayerController.dead = true;
				StartCoroutine(GoalReached());
			}
		}
	}

	private IEnumerator GoalReached() {
		yield return new WaitForSeconds(2f);

		LevelController.instance.NextLevel();
		yield break;
	}
}
