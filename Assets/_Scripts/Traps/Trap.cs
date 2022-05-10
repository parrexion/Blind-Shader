using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public Transform ping;
	public float pingSpeed;


	public virtual bool Activate() {
		return false;
	}

	protected void CreateSinglePing() {
		Vector3 pingLocation = new Vector3(transform.localPosition.x, 3f, transform.localPosition.z);
		Transform p = Instantiate(ping, pingLocation, ping.localRotation);
		if (pingSpeed > 0) {
			p.GetComponent<Ping>().speed = pingSpeed;
		}
		p.GetComponent<SpriteRenderer>().color = Color.red;
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
