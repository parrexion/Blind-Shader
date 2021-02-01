using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesChecking : MonoBehaviour {

	public Transform ping;
	public Color pingColor = Color.white;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall") {
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f,transform.localPosition.z);
			Transform p = Instantiate(ping,pingLocation,ping.localRotation);
			p.GetComponent<SpriteRenderer>().color = pingColor;
		}
	}
}
