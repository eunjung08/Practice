using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGenerator myGenerator = (MapGenerator)target;
        if(GUILayout.Button("맵을 생성합니다"))
        {
            myGenerator.BuildGenerator();
        }
    }
}
