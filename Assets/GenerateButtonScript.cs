using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CaveGeneration))]
public class GenerateScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CaveGeneration myScript = (CaveGeneration)target;
        if (GUILayout.Button("Generate Terrain"))
        {
            myScript.generate();
        }
    }
}

