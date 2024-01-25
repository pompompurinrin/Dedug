using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopImage : MonoBehaviour
{
    public float speed;
    RawImage image;
    Vector2 imageSize;
    void Start()
    {
        image = GetComponent<RawImage>();
        imageSize = image.uvRect.size; 

    }
    void Update()
    {
        float x = image.uvRect.x;
        float y = image.uvRect.y;
        x += Time.deltaTime * speed;
        image.uvRect = new Rect(new Vector2(x, y), imageSize);

    }
}
