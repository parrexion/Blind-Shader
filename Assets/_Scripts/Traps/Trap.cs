using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour {

	public Transform ping;
	public float pingSpeed;


	protected void CreateSinglePing() {
		Vector3 pingLocation = new Vector3(transform.localPosition.x, 5f, transform.localPosition.z);
		Transform p = Instantiate(ping, pingLocation, ping.localRotation);
		if (pingSpeed > 0)
			p.GetComponent<Ping>().speed = pingSpeed;
	}

	protected void CreatePings(int pings, float interval) {
		StartCoroutine(PingInterval(pings, interval));
	}

	IEnumerator PingInterval(int pings, float interval) {
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

	IEnumerator Respawn() {

		yield return new WaitForSeconds(2f);

		LevelController.instance.RestartLevel();

		yield break;
	}


	public virtual bool Activate() {
		return false;
	}
}
