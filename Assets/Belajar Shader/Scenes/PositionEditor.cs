using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PositionView))]
public class PositionEditor : Editor
{
    private void OnSceneGUI()
    {
        PositionView pv = (PositionView)target;
        if(target == null) return;
        
        foreach (var vertex in pv._vertices)
        {
            string vert = "Object View: " + vertex;
            string worldVert = "World View: " + (pv.transform.position + vertex);
            Handles.color = Color.red;
            Handles.Label(pv.transform.position + vertex, vert + "\n" + worldVert);
        }
        
    }
}