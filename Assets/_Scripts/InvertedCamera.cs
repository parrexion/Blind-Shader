using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedCamera : MonoBehaviour {

	public Shader invertShader;


	void OnEnable () {
		GetComponent<Camera>().SetReplacementShader(invertShader, "");
	}

	void OnDisable() {
		GetComponent<Camera>().ResetReplacementShader();
	}
	
}
