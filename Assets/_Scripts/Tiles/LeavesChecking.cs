using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesChecking : MonoBehaviour {

	public Transform ping;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log("Leaves");
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f,transform.localPosition.z);
			Instantiate(ping,pingLocation,ping.localRotation);
		}
	}
}
