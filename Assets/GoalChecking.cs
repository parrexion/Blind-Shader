using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalChecking : MonoBehaviour {

	public Text winText;

	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			if (other.GetComponent<PlayerController>().hasKey)
				winText.enabled = true;
		}
	}
}
