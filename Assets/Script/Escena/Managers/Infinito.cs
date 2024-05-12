using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinito : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.5f;
    [SerializeField]private MeshRenderer _mesh;
    
   
    void Update()
    {
        Vector2 offset = new Vector2(  Time.time *_scrollSpeed,0 );
        _mesh.material.mainTextureOffset = offset;
    }
}
