using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyChecking : MonoBehaviour {

	public Transform ping;
	

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Found Key");
			other.GetComponent<PlayerController>().AqcuireKey();
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f,transform.localPosition.z);
			Instantiate(ping,pingLocation,ping.localRotation);
			Destroy(gameObject);
		}
	}
}
