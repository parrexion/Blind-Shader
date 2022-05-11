using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform player;
	public float speed;
	public float offScreenX;
	public AudioClip hitSfx;

	public float IsFlyingFloat => (isActive) ? 1f : 0f;

	private bool isFlying = false;
	private bool isActive = false;
	// private float currentTime = 0;


	private void Start() {
		OffscreenPostition();
		isFlying = false;
	}

	private void Update() {
		// currentTime -= Time.deltaTime;

		// if (currentTime <= 0) {
		// 	ResetPostition();
		// 	isFlying = false;
		// 	isActive = false;
		// 	return;
		// }

		if (!isActive && !isFlying)
			OffscreenPostition();

		if (isFlying)
			transform.Translate(speed * Time.deltaTime * Vector3.forward);
	}

	public void ResetPostition() {
		transform.localPosition = player.transform.localPosition;
		isActive = false;
	}

	public void OffscreenPostition() {
		transform.localPosition = new Vector3(offScreenX, 0, 0);
		isActive = false;
	}

	public void Fire(/*float time,*/ Quaternion rotation) {
		ResetPostition();
		transform.localRotation = rotation;
		// currentTime = time;
		isFlying = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Wall")) {
			isFlying = false;
			isActive = true;
			if(hitSfx)
				AudioController.instance.PlaySfx(hitSfx);
		}
	}

}
