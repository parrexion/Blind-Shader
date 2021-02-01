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

#if UNITY_ANDROID
		if (Input.GetKeyDown(KeyCode.X))
			Fire();
#else
		if(Input.GetMouseButtonDown(0)) {
			Fire();
		}
#endif
	}

	// Update is called once per frame
	public void Fire() {
		if (cooldown > 0)
			return;

		cooldown = timeBetweenShots;
		bullet.Fire(transform.localRotation);
	}

	void UpdateCooldown() {
		cooldownUI.fillAmount = Mathf.Clamp01((timeBetweenShots-cooldown)/timeBetweenShots);
	}
}
