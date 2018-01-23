using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform player;
	public float speed;

	private bool isFlying = false;
	private bool isActive = false;
	// private float currentTime = 0;


	// Use this for initialization
	void Start() {
		ResetPostition();
		isFlying = false;
	}

	// Update is called once per frame
	void Update() {
		// currentTime -= Time.deltaTime;

		// if (currentTime <= 0) {
		// 	ResetPostition();
		// 	isFlying = false;
		// 	isActive = false;
		// 	return;
		// }

		if (!isActive && !isFlying)
			ResetPostition();

		if (isFlying)
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	public void ResetPostition() {
		transform.localPosition = player.transform.localPosition;
		isActive = false;
	}

	public void Fire(/*float time,*/ Quaternion rotation) {
		ResetPostition();
		transform.localRotation = rotation;
		// currentTime = time;
		isFlying = true;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Wall") {
			isFlying = false;
			isActive = true;
		}
	}

	public float GetIsFlyingFloat() {
		return (isActive) ? 1f : 0f;
	}
}
