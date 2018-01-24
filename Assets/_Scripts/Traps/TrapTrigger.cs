using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour {

	public Trap trapToTrigger;

	private Collider col;


	void Start() {
		col = GetComponent<Collider>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Trigger");
			bool res = trapToTrigger.Activate();
			if (res) {
				col.enabled = false;
			}
		}
	}
}
