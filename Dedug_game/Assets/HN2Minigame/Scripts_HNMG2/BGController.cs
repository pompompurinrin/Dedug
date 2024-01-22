using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    private MeshRenderer render;


    public float offset;
    public float speed;

    void Start()
    {
        render = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2( 0, offset );
    }
}
