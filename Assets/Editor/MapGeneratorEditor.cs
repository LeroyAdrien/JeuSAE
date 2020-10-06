using System.Collections;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MapGenerator))]

public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {

        MapGenerator MapGen = (MapGenerator)target;

        
        if (DrawDefaultInspector())
        {

        }

        if (GUILayout.Button("Generate"))
        {
            MapGen.GenerateMap();
        }
/*
        if (GUILayout.Button("Reset"))
        {
            MapGen.Reset();
        }
*/
        
    }
}
