using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public bool invert;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float value = (invert) ? 0.01f : -0.01f;
		GetComponent<Rigidbody2D>().MovePosition(new Vector3(0, 0, value));
		//transform.Translate(new Vector3(0, 0, value));
	}
}
