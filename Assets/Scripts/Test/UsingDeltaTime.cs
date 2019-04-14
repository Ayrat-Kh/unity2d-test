using UnityEngine;
using System.Collections;

public class UsingDeltaTime : MonoBehaviour
{
    public float speed = 8f;
    public float countdown = 3.0f;


    void Update()
    {
        // Применяется для выравнивания значенний
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
            GetComponent<Light>().enabled = true;

        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}