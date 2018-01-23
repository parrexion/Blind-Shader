using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public bool hasKey = false;
	public Image keyImage;

	private Rigidbody rigid;
	private Vector3 inputVector;
	private Vector3 moveVelocity;
	private Camera mainCamera;
	private FireShot shooter;


	void Start() {
		rigid = GetComponent<Rigidbody>();
		shooter = GetComponent<FireShot>();
		mainCamera = FindObjectOfType<Camera>();
	}

	void Update() {
		inputVector = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
		moveVelocity = inputVector * moveSpeed;

		Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		if (groundPlane.Raycast(cameraRay, out rayLength)) {
			Vector3 pointToLook = cameraRay.GetPoint(rayLength);
			Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
		}

		if (Input.GetMouseButtonDown(0)) {
			shooter.Fire();
		}
	}

	void FixedUpdate() {
		rigid.velocity = moveVelocity;
	}


	public void AqcuireKey() {
		hasKey = true;
		keyImage.enabled = true;
	}
}