using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PositionView : MonoBehaviour
{
    private Mesh _mesh;
    public Vector3[] _vertices;


    private void OnDrawGizmos()
    {
        if (_vertices == null)
        {
            _mesh = GetComponent<MeshFilter>().sharedMesh;
            _vertices = _mesh.vertices;
        }
    }
}
