using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMover : MonoBehaviour
{
    public Vector2 direction;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
