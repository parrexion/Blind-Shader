using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ProximityXray : MonoBehaviour {

	public Transform player;
	public Bullet shot;
	Renderer render;


	// Use this for initialization
	void Start () {

		render = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {

		render.sharedMaterial.SetVector("_PlayerPosition", player.position);
		render.sharedMaterial.SetVector("_ShotPosition", shot.transform.position);
		render.sharedMaterial.SetFloat("_UseShot", shot.GetIsFlyingFloat());
	} 
 }