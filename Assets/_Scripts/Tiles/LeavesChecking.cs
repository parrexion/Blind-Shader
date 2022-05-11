using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesChecking : MonoBehaviour {

	public Ping ping;
	public Color pingColor = Color.white;
	public AudioClip[] triggerSfx;
	public float volumeScale = 0.5f;

	private int sfxCount;


	private void Start() {
		sfxCount = triggerSfx.Length;	
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall")) {
			Vector3 pingLocation = new Vector3(transform.localPosition.x, 1f, transform.localPosition.z);
			Ping p = Instantiate(ping, pingLocation, ping.transform.localRotation);
			p.spriteRenderer.color = pingColor;
			if (sfxCount > 0)
				AudioController.instance.PlaySfx(triggerSfx[Random.Range(0, sfxCount)], volumeScale);
		}
	}
}
