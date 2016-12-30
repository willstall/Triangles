using UnityEngine;
using System.Collections;

public class OscillateScale : MonoBehaviour
{
    
    public float frequency = 2;
    public Vector3 amplitude = Vector3.one; 
    public bool startWithRandomOffset;   
    
    Vector3 startScale;
    float offset;

    void Start()
    {
        startScale = transform.localScale;

        offset = 0.0f;
        if(startWithRandomOffset)
            offset = Random.Range(0,10000);
    }
        
    void Update ()
    {
        Vector3 scale = startScale + Mathf.Sin( (Time.time + offset) * frequency ) * amplitude;
        transform.localScale = scale;
    }
}