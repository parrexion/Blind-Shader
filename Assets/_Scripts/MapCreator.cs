using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {

	public Texture2D map;
	public float tileOffset;

	private ColorPrefabs colorPrefabs;
	public Transform player;


	// Use this for initialization
	void Start () {

		colorPrefabs = GetComponent<ColorPrefabs>();

		for (int x = 0; x < map.width; x++) {
			for (int y = 0; y < map.height; y++) {
				GenerateTile(x,y);
			}
		}
	}


	void GenerateTile(int x, int y) {

		Vector3 position = new Vector3(x, 0.1f, y);
		Color pixelColor = map.GetPixel(x, y);

		Transform tile = null;

		if (pixelColor.a == 0f) { //pixelColor.r * pixelColor.g * pixelColor.b == 1) {
			//Empty space
		}
		else if (pixelColor.r + pixelColor.g + pixelColor.b == 0) {
			// Debug.Log("BLACK");
			tile = colorPrefabs.black;
			position += new Vector3(0, 0.4f, 0);
		}
		else if (pixelColor.r == 1f) {
			Debug.Log("RED");
			tile = colorPrefabs.red;
		}
		else if (pixelColor.g == 1f) {
			Debug.Log("GREEN");
			tile = colorPrefabs.green;
			player.transform.localPosition = new Vector3(position.x, 1,position.z);
		}
		else if (pixelColor.b == 1f) {
			Debug.Log("BLUE");
			tile = colorPrefabs.blue;
		}
		else if (pixelColor.r > 0.5f && pixelColor.g > 0.5f && pixelColor.b < 0.5f) {
			Debug.Log("YELLOW");
			tile = colorPrefabs.yellow;
		}
		else if (pixelColor.r < 0.5f && pixelColor.g > 0.5f && pixelColor.b > 0.5f) {
			Debug.Log("CYAN");
			tile = colorPrefabs.cyan;
		}
		else if (pixelColor.r > 0.5f && pixelColor.g < 0.5f && pixelColor.b > 0.5f) {
			Debug.Log("MAGENTA");
			tile = colorPrefabs.magenta;
		}
		else {
			Debug.Log("X: " + x + ", Y" + y);
			Debug.Log("Hmm. " + pixelColor);
		}

		if (tile == null)
			return;

		Instantiate(tile, position, Quaternion.identity, transform);
	}
	
}
