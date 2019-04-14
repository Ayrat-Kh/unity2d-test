using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHealth : MonoBehaviour
{
    /// <summary>
    /// Жизнь
    /// </summary>
    [SerializeField]
    private StatHealth health;

    /// <summary>
    /// ссылка на изображение, которое будет заполнятся 
    /// </summary>
    private Image content;

    /// <summary>
    /// Это текст (100/100) который будет менятся 
    /// </summary>
    [SerializeField]
    private Text statValue;

    /// <summary>
    /// Скорость интерполяции
    /// </summary>
    [SerializeField]
    private float LerpSpeed ;

    /// <summary>
    ///Текущее заполнение (в долях единиц) от 0 до 1
    /// </summary>
    private float CurrentFill;

    /// <summary>
    /// Максимальное значение для Health
    /// </summary>
    private float MaxHealth { get; set; }

    /// <summary>
    /// Текущее значение Health
    /// </summary>
    private float CurrentHealth;

    /// <summary>
    /// Значение для установки CurrentHealth и MaxHealth для health
    /// </summary>
    [SerializeField]
    private float initHealph = 100;

    /// <summary>
    /// Свойство для настройки текущего значения(CurrentHealth),
    ///используется каждый раз когда меняется текущее значение(CurrentHealth)
    /// </summary>
    public float MyCurrentHealth
    {
        get
        {
            return CurrentHealth;
        }
        set
        {    
            //Если CurrentValue становится больше Максимального значения
            if (value > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            //Если CurrentValue меньше 0
            else if (value < 0)
            {
                CurrentHealth = 0;
            }
            //Если CurrentValue меньше максимального значения и больше 0 
            else
            {
                CurrentHealth = value;
            }

            //Текст будет менятся каждый раз, когда вызывается свойство MyCurrentHealth
            statValue.text = CurrentHealth + " / " + MaxHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponent<Stat>();

        content = GetComponent<Image>();

        health.InitializeHealth(initHealph, initHealph);
    }


    void Update()
    {
        ChangeCurrenFill();
        ChangeStatValue();
       
        DemoStat();
    }

    /// <summary>
    /// Устанавливает значение  CurrentHealth(Текущее значение) и MaxHealth(Макимальное значение) 
    /// </summary>
    public void InitializeHealth (float maxValue, float currentValue )
    {
        MaxHealth = maxValue;
        CurrentHealth = currentValue;
    }

    /// <summary>
    /// Изменяет текущее заполнение
    /// </summary>
    public void ChangeCurrenFill()
    {
        //Рассчитываем текущее заполнение(в долях), что бы мы могли его интерполировать
        CurrentFill = CurrentHealth / MaxHealth;

        //Если CurrentFill отличается от Установленного заполнения
        if (CurrentFill != content.fillAmount)
        {
            //Заполнение меняется от установленного заполнения до текущего с шагом LerpSpeed)
            content.fillAmount =
                Mathf.Lerp(content.fillAmount, CurrentFill, Time.deltaTime * LerpSpeed);
        }

        //content.fillAmount = CurrentFill;
    }

    /// <summary>
    /// Изменяет Текст, а именно StatValue
    /// </summary>
    public void ChangeStatValue()
    {
        //Отображает слева  текущее значение справа максимальное
        statValue.text = CurrentHealth + " / " + MaxHealth;
    }

    public void DemoStat()
    {
        ///ЭТО ИСПОЛЬЗУЕТСЯ ЛИШЬ ДЛЯ ПРОВЕРКИ
        ///
        if (Input.GetKeyDown(KeyCode.K))
        {
            health.MyCurrentHealth -= 10f;   
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            health.MyCurrentHealth += 10f;           
        }
    }
}
