using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecking : MonoBehaviour {

	public Collider keyCollider;
	public GameObject keyObject;
	public Transform ping;
	

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			Debug.Log("Found Key");
			other.GetComponent<PlayerController>().AqcuireKey();
			Vector3 pingLocation = new Vector3(transform.position.x, 1f,transform.position.z);
			Transform p = Instantiate(ping,pingLocation,ping.transform.localRotation);
			p.GetComponent<SpriteRenderer>().color = Color.yellow;

			keyObject.SetActive(false);
			keyCollider.enabled = false;
		}
	}
}
