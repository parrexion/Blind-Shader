using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireShot : MonoBehaviour {
	
	public Bullet bullet;
	public Image cooldownUI;
	public float timeBetweenShots;
	public AudioClip shootSfx;

	private float cooldown;


	private void Start() {
		BigTextUI ui = FindObjectOfType<BigTextUI>();
		cooldownUI = ui.fireButton.image;
		ui.fireButton.onClick.AddListener(Fire);
	}

	private void Update() {
		cooldown -= Time.deltaTime;
		UpdateCooldown();

#if UNITY_ANDROID && UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.X))
			Fire();
#else
		if(Input.GetMouseButtonDown(0)) {
			Fire();
		}
#endif
	}

	public void Fire() {
		if (cooldown > 0 || PlayerController.dead)
			return;

		cooldown = timeBetweenShots;
		bullet.Fire(transform.localRotation);
		if (shootSfx)
			AudioController.instance.PlaySfx(shootSfx);
	}

	private void UpdateCooldown() {
		cooldownUI.fillAmount = Mathf.Clamp01((timeBetweenShots-cooldown)/timeBetweenShots);
	}
}
