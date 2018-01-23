using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireShot : MonoBehaviour {
	
	public Bullet bullet;
	public Image cooldownUI;

	public float timeBetweenShots;
	private float cooldown;

	
	void Update() {
		cooldown -= Time.deltaTime;
		UpdateCooldown();
	}

	// Update is called once per frame
	public void Fire() {

		if (cooldown > 0)
			return;

		cooldown = timeBetweenShots;
		bullet.Fire(/*timeBetweenShots,*/ transform.localRotation);
	}

	void UpdateCooldown() {
		cooldownUI.fillAmount = Mathf.Clamp01((timeBetweenShots-cooldown)/timeBetweenShots);
	}
}
