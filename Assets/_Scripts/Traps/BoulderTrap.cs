using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrap : Trap {

	public bool isActive = false;
	public Vector2 rollSpeed;
	public float pingInterval;
	public AudioSource rollingSound;
	public AudioClip hitSfx;

	private float currentPingTime;
	private Vector3 speed;


	// Use this for initialization
	void Start () {
		isActive = false;
		speed = new Vector3(rollSpeed.x, 0, rollSpeed.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive)
			return;

		currentPingTime -= Time.deltaTime;
		if (currentPingTime <= 0) {
			CreateSinglePing();
			currentPingTime = pingInterval;
		}

		transform.Translate(speed * Time.deltaTime);
	}

	public override bool Activate() {
		isActive = true;
		rollingSound.volume = AudioController.instance.sfxVolume;
		rollingSound.Play();
		return true;
	}

	void OnTriggerEnter(Collider other) {
		if (isActive && other.gameObject.CompareTag("Player")) {
			KillPlayer();
			if(killSfx)
				AudioController.instance.PlaySfx(killSfx);
		}
		else if (other.gameObject.CompareTag("Wall")) {
			isActive = false;
			GetComponent<Collider>().isTrigger = false;
			CreateSinglePing();
			rollingSound.Stop();
			if(hitSfx)
				AudioController.instance.PlaySfx(hitSfx);
		}
	}
}
