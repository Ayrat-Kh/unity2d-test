using UnityEngine;

public class ImpelseMover : MonoBehaviour
{
    public Vector2 direction2;
    public float acceleration;  //ускорение
    public Rigidbody rb;        //ссылка на компонент рижидбоди

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(direction2.normalized * acceleration, ForceMode.Impulse);
        }

    }
}
