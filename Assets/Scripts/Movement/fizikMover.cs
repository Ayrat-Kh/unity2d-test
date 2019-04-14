using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fizikMover : MonoBehaviour
{
    public Vector2 direction2;
    public float acceleration;  //ускорение
    public Rigidbody rb ;      //ссылка на компонент рижидбоди

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        //direction2.normalized - приведенная к единице
        rb.AddForce(direction2.normalized * acceleration);
    }
}
