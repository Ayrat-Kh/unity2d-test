using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public Rigidbody bulletPrefab; //Преваб для пуль
    public Transform firePosition; // Позиция пуль
    public float bulletSpeed; // скорость пуль


    private Inventory inventory; //обращаемся к скрипту инвентори


    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }


    void Update()
    {
        Shoot();  //проверять учловие каждый кадр
    }


    void Shoot()
    {
        // Если зажата левая кнопка мыши и пули в инвентаре > 0
        if (Input.GetButtonDown("Fire1") && inventory.myStuff.bullets > 0)
        {
            //Instantiate   - 	Clones the object original and returns the clone.
            //
            Rigidbody bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
            bulletInstance.AddForce(firePosition.forward * bulletSpeed);
            inventory.myStuff.bullets--;
        }
    }
}