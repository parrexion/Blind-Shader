using UnityEngine;
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
	private Camera mainCamera;


	void Start() {
		rigid = GetComponent<Rigidbody>();
		mainCamera = FindObjectOfType<Camera>();
	}

	void Update() {
		if (dead || !Input.GetMouseButton(0) || EventSystem.current.IsPointerOverGameObject()) {
			moveVelocity = Vector3.zero;
			return;
		}

		//Handling moving
		Ray cameraRay;
		if (Application.platform == RuntimePlatform.Android)
			cameraRay = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
		else
			cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		if (!groundPlane.Raycast(cameraRay, out rayLength)) 
			return;

		Vector3 pointToLook = cameraRay.GetPoint(rayLength);
		Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
		transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

		moveVelocity = new Vector3(pointToLook.x - transform.position.x, 1, pointToLook.z - transform.position.z);
		moveVelocity = moveSpeed * moveVelocity.normalized;
	}

	void FixedUpdate() {
		rigid.velocity = moveVelocity;
	}


	public void AqcuireKey() {
		hasKey = true;
		keyImage.enabled = true;
	}
}