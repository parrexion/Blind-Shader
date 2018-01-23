using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {

	public float speed;
	public float maxSize;

	private float currentScale;


	// Use this for initialization
	void Start () {
		currentScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		currentScale += Time.deltaTime * speed;

		if (currentScale >= maxSize){

			// currentScale = 1;
			Destroy(gameObject);
		}

		transform.localScale = new Vector3(currentScale,currentScale,currentScale);
	}
}
