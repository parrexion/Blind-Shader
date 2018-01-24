using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(MapCreator))]
public class MapCreatorEditor : Editor {


	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		GUILayout.Space(20);

		if (GUILayout.Button("Generate Map", GUILayout.Height(50))) {
			GenerateMap();
		}
	}

	void GenerateMap() {
		MapCreator map = (MapCreator)target;
		map.GenerateMap();
		EditorUtility.SetDirty(map);
		EditorSceneManager.MarkSceneDirty(map.gameObject.scene);
	}
}
