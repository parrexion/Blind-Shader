using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public float speed;
	public float maxSize;

	private float currentScale;


	private void Start () {
		currentScale = 1;
	}
	
	private void Update () {
		currentScale += Time.deltaTime * speed;

		if (currentScale >= maxSize){
			// currentScale = 1;
			Destroy(gameObject);
		}
		else {
			transform.localScale = new Vector3(currentScale,currentScale,currentScale);
		}
	}
}
