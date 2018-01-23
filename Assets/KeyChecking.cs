using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChecking : MonoBehaviour {

	public Text winText;

	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Found Key");
			other.GetComponent<PlayerController>().AqcuireKey();
			Destroy(gameObject);
		}
	}
}
