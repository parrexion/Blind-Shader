using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGuard : Trap {

	public Transform[] waypointList;
	public float speed;
	public float turnTime;

	private int currentWaypoint;
	private float waitTime;
	private float distance;


	void Update() {
		if(waitTime > 0) {
			waitTime -= Time.deltaTime;
			return;
		}

		distance = Vector3.Distance(transform.position, waypointList[currentWaypoint].position);
		if(distance < 0.01f) {
			currentWaypoint = (currentWaypoint + 1) % waypointList.Length;
			waitTime = turnTime;
		} else {
			Vector3 moveSpeed = Vector3.MoveTowards(transform.position, waypointList[currentWaypoint].position, speed * Time.deltaTime);
			transform.position = moveSpeed;
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Player")) {
			CreatePings(2, 0.15f);
			KillPlayer();
			if(killSfx)
				AudioController.instance.PlaySfx(killSfx);
		}
	}

}
