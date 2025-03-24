using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRotate : MonoBehaviour
{
    [SerializeField] Material material;
    private float x, y; 
    void Update()
    {
        x += Time.deltaTime;
        y += Time.deltaTime; 
        material.mainTextureOffset = new Vector2(x, y);
    }
}
