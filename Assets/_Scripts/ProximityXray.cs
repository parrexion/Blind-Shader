using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ProximityXray : MonoBehaviour {

	public Transform player;
	public Bullet shot;
	// Renderer render;


	//void Start () {

	//	render = gameObject.GetComponent<Renderer>();
	//}
	
	// Update is called once per frame
	void Update () {

		//render.sharedMaterial.SetVector("_PlayerPosition", player.position);
		//render.sharedMaterial.SetVector("_ShotPosition", shot.transform.position);
		//render.sharedMaterial.SetFloat("_UseShot", shot.IsFlyingFloat);

		Shader.SetGlobalVector("_PlayerPosition", player.position);
		Shader.SetGlobalVector("_ShotPosition", shot.transform.position);
		Shader.SetGlobalFloat("_UseShot", shot.IsFlyingFloat);
	}
}