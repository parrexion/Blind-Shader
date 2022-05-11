using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {

	public ColorPrefabs normalPrefabs;
	public ColorPrefabs blindPrefabs;
	public Transform player;
	public Transform mapTransform;

	[Header("Map settings")]
	public Texture2D map;
	public float tileOffset;
	public bool useBlind;


	/// <summary>
	/// Generate map
	/// </summary>
	public void GenerateMap () {
		// Remove old map
		List<GameObject> children = new List<GameObject>();
		foreach (Transform child in mapTransform) 
			children.Add(child.gameObject);
		children.ForEach(child => DestroyImmediate(child));
		Color32[] colorData = map.GetPixels32();

		// Create new map
		for (int x = 0; x < map.width; x++) {
			for (int y = 0; y < map.height; y++) {
				GenerateTile(colorData[x + y*map.width], x,y);
			}
		}
	}


	private void GenerateTile(Color32 pixelColor, int x, int y) {
		Vector3 position = new Vector3(x, 0.1f, y);
		ColorPrefabs colorPrefabs = (useBlind) ? blindPrefabs : normalPrefabs;

		Transform tile = null;

		if (pixelColor.a == 0 || (pixelColor.r == 255 && pixelColor.g == 255 && pixelColor.b == 255)) {
			//Empty space
		}
		else if (pixelColor.r + pixelColor.g + pixelColor.b == 0) {
			// Debug.Log("BLACK");
			tile = colorPrefabs.black;
			position += new Vector3(0, 0.4f, 0);
		}
		else if (pixelColor.r == 255) {
			//Debug.Log("RED");
			tile = colorPrefabs.red;
		}
		else if (pixelColor.g == 255) {
			//Debug.Log("GREEN");
			tile = colorPrefabs.green;
			player.transform.localPosition = new Vector3(position.x, 1,position.z);
		}
		else if (pixelColor.b == 255) {
			//Debug.Log("BLUE");
			tile = colorPrefabs.blue;
		}
		else if (pixelColor.r > 128 && pixelColor.g > 128 && pixelColor.b < 128) {
			//Debug.Log("YELLOW");
			tile = colorPrefabs.yellow;
		}
		else if (pixelColor.r < 128 && pixelColor.g > 128 && pixelColor.b > 128) {
			//Debug.Log("CYAN");
			tile = colorPrefabs.cyan;
		}
		else if (pixelColor.r > 128 && pixelColor.g < 128 && pixelColor.b > 128) {
			//Debug.Log("MAGENTA");
			tile = colorPrefabs.magenta;
		}
		else {
			Debug.Log("X: " + x + ", Y" + y);
			Debug.Log("Hmm. " + pixelColor);
		}

		if (tile == null)
			return;

		Instantiate(tile, position, Quaternion.identity, mapTransform);
	}
	
}
