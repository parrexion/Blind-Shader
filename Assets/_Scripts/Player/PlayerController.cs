﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static bool dead = false;
	public float moveSpeed;
	public bool hasKey = false;
	public Image keyImage;

	private Rigidbody rigid;
	private Vector3 inputVector;
	private Vector3 moveVelocity;
	private Joystick joystick;
	private Camera mainCamera;


	void Start() {
		mainCamera = Camera.main;
		rigid = GetComponent<Rigidbody>();
		joystick = FindObjectOfType<Joystick>();
	}

	void Update() {
		if(dead) {
			moveVelocity = Vector3.zero;
			return;
		}

#if UNITY_ANDROID
		Vector3 pointToLook = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
		moveVelocity = moveSpeed * pointToLook;
		if (pointToLook != Vector3.zero)
			transform.localRotation = Quaternion.LookRotation(pointToLook.normalized);
#else
		inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		moveVelocity = inputVector * moveSpeed;

		Ray cameraRay;
		if(Application.platform == RuntimePlatform.Android)
			cameraRay = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
		else
			cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		if(!groundPlane.Raycast(cameraRay, out rayLength))
			return;

		Vector3 pointToLook = cameraRay.GetPoint(rayLength);
		Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
		transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
#endif
	}

	void FixedUpdate() {
		rigid.velocity = moveVelocity;
	}


	public void AqcuireKey() {
		hasKey = true;
		keyImage.enabled = true;
	}
}