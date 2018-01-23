using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchChecking : MonoBehaviour {

	public Transform ping;
	public GameObject key;

	void Start() {
		StartCoroutine(FindKey());
	}

	IEnumerator FindKey() {
		yield return new WaitForSeconds(1f);
		key = GameObject.Find("Key(Clone)");
		key.SetActive(false);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Switch");
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f,transform.localPosition.z);
			Instantiate(ping,pingLocation,ping.localRotation);
			pingLocation = new Vector3(key.transform.localPosition.x, 1f,key.transform.localPosition.z);
			Instantiate(ping,pingLocation,ping.localRotation);
			key.SetActive(true);
		}
	}
}
