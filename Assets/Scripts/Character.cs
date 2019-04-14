using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// скорость игрока
    /// </summary>
    [SerializeField] //этот атрибут делает видимым в редакторе юнити приватное поле 
    [Range(0.0f, 15.0f)] //этот атрибут делает ползунок в редакторе юнити (min, max)
    protected float speed;

    /// <summary>
    /// направление игрока
    /// </summary>
    protected Vector3 directionn;

    /// <summary>
    /// ссылка на физ. тело
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// ccылка на аниматор
    /// </summary>
    protected Animator animator;


    private void Awake()
    {
        //Вызывается для каждого объекта
        //в книгах пишут лучше инициализировать значения
        // в этих методах
    }

    protected virtual void Start()
    {
        //speed = 10;

        //Присвоим значение(физ.тело) объекту
        //крч, что бы сам находил и брал компонент
        rb = GetComponent<Rigidbody2D>();

        //что бы брал из объекта
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        //Запускает метод AnimateMovement()
        AnimateMovement(directionn);
    }

    // Так как физ.объект, применяем Fixed 
    protected virtual void FixedUpdate()
    {
        //Запускает метод Move()
        Move();  
        

    }

    /// <summary>
    /// Движение Игрока
    /// </summary>
    public void Move()
    {
        //перемещает rigidbody по позиции.
        rb.MovePosition(transform.position + directionn * speed * Time.deltaTime);

        // придаем силу = направление * скорость
        //rb.AddForce(directionn.normalized * speed);
    }

    /// <summary>
    /// Анимация игрока, движение и простаивание (move, idle)
    /// </summary>
    private void AnimateMovement(Vector3 direction)
    {
        
        //Используем это условие, что бы персонаж не переключался к стандартной анимации
        //т.е к idle анимации, при повороте в разные стороны
        if (direction != Vector3.zero)
        {
            //В Аниматоре устанавливаем значение MoveX равным изменениям по х (от -1 до 1)
            animator.SetFloat("MoveX", directionn.x);

            //то есть значения полученные через Input.GetAxis
            animator.SetFloat("MoveY", directionn.y);

            //устанавливаем значение moving в аниматоре (true или false)
            animator.SetBool("moving", true);
        }
        //Если равно нулю
        else
        {
            //устанавливаем значение moving в аниматоре (true или false)
            animator.SetBool("moving", false);

            //тут можно что нибудь дописать 
            Debug.Log("0");
        }
    }
}
