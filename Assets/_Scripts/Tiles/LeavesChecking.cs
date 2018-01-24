using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesChecking : MonoBehaviour {

	public Transform ping;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall") {
			Debug.Log("Leaves");
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f,transform.localPosition.z);
			Instantiate(ping,pingLocation,ping.localRotation);
		}
	}
}
