using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMover : MonoBehaviour
{

    public Vector2 startP;
    public Vector2 end;
    public float step;
    float progress;

    void Start()
    {
        transform.position = startP;
    }

   
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(startP, end, progress);
        progress += step;
    }
}
