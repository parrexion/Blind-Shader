using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikesChecking : Trap {

	private Text winText;

	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			CreatePings(2,0.15f);
			KillPlayer();
		}
	}
}
