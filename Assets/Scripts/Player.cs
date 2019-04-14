using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : Character
{
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        //Запускает метод GetInput()
        GetInput();

        //Запустить базовый вторым в очереди
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Ввод и чтение даннных осей координат
    /// </summary>
    private void GetInput()
    {
        // Всегда = 0 если не нажата не одна из клавиш
        directionn = Vector3.zero;

        //Задаем значения по х, возвращает от -1 до 1
        directionn.x = Input.GetAxis("Horizontal");

        //Задаем значения по y, возвращает от -1 до 1
        directionn.y = Input.GetAxis("Vertical");

        //Ограничим движение по диагонали той же скоростью, что и движение параллельно осям.
        //ClampMagnitude Возвращает копию vector3 фиксированной величиной maxLength.
        directionn = Vector3.ClampMagnitude(directionn, 1);

        //для проверки
        Debug.Log(directionn);

        //if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log("1");
        //    directionn += Vector3.right;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    Debug.Log("2");
        //    directionn += Vector3.left;
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    Debug.Log("3");
        //    directionn += Vector3.forward;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    Debug.Log("4");
        //    directionn += Vector3.back;
        //}
    }

}
