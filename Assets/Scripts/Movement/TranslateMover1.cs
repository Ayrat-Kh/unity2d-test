using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMover1 : MonoBehaviour
{
    public Vector2 direction1;
    public float speed;
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        transform.Translate(direction1.normalized *speed *  Time.deltaTime );
    }
}
