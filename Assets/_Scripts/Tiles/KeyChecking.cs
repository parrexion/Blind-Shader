using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecking : MonoBehaviour {

	public Collider keyCollider;
	public GameObject keyObject;
	public Ping ping;
	public AudioClip pickupSfx;
	

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			other.GetComponent<PlayerController>().AqcuireKey();

			Vector3 pingLocation = new Vector3(transform.position.x, 1f, transform.position.z);
			Ping p = Instantiate(ping, pingLocation, ping.transform.localRotation);
			p.spriteRenderer.color = Color.yellow;

			keyObject.SetActive(false);
			keyCollider.enabled = false;
			if (pickupSfx)
				AudioController.instance.PlaySfx(pickupSfx);
		}
	}
}
