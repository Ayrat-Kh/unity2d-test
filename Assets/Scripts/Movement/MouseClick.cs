using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{
    public float impulse;
    public void OnMouseDown()
    {
        Debug.Log(" click ");

        GetComponent<Rigidbody>().AddForce(transform.forward * impulse );
        GetComponent<Rigidbody>().useGravity = false;

    }
    public void Update()
    {

    }
}