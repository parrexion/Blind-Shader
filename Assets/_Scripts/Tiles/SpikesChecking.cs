using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesChecking : Trap {

	public GameObject[] spikes = new GameObject[0];


	private void Start() {
		for(int i = 0; i < spikes.Length; i++) {
			spikes[i].SetActive(false);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			CreatePings(2,0.15f);
			KillPlayer();
			for(int i = 0; i < spikes.Length; i++) {
				spikes[i].SetActive(true);
			}

			if(killSfx)
				AudioController.instance.PlaySfx(killSfx);
		}
	}
}
