using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour {
	
	public Bullet bullet;

	public float timeBetweenShots;
	private float cooldown;

	
	void Update() {
		cooldown -= Time.deltaTime;
	}

	// Update is called once per frame
	public void Fire() {

		if (cooldown > 0)
			return;

		cooldown = timeBetweenShots;
		bullet.Fire(timeBetweenShots, transform.localRotation);
	}
}
