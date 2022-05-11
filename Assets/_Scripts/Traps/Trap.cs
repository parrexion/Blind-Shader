using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public Ping ping;
	public float pingSpeed;
	public AudioClip killSfx;


	public virtual bool Activate() {
		return false;
	}

	protected void CreateSinglePing() {
		Vector3 pingLocation = new Vector3(transform.localPosition.x, 3f, transform.localPosition.z);
		Ping p = Instantiate(ping, pingLocation, ping.transform.localRotation);
		if (pingSpeed > 0) {
			p.speed = pingSpeed;
		}
		p.spriteRenderer.color = Color.red;
	}

	protected void CreatePings(int pings, float interval) {
		StartCoroutine(PingInterval(pings, interval));
	}

	private IEnumerator PingInterval(int pings, float interval) {
		CreateSinglePing();

		for (int i = 1; i < pings; i++) {
			yield return new WaitForSeconds(interval);
			CreateSinglePing();
		}

		yield break;
	}

	protected void KillPlayer() {
		BigTextUI winText = FindObjectOfType<BigTextUI>();
		winText.ShowDeath();
		PlayerController.dead = true;
		StartCoroutine(Respawn());
	}

	private IEnumerator Respawn() {
		yield return new WaitForSeconds(2f);

		LevelController.instance.RestartLevel();
		yield break;
	}

}
