using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    /// <summary>
    /// Жизнь
    /// </summary>
    [SerializeField]
    private Stat health;

    /// <summary>
    /// Мана
    /// </summary>
    [SerializeField]
    private Stat mana;

    /// <summary>
    /// ссылка на изображение, которое будет заполнятся 
    /// </summary>
    private Image content;

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

    // <summary>
    /// Максимальное значение для Mana
    /// </summary>
    private float MaxMana { get; set; }

    /// <summary>
    /// Текущее значение, например, текущее состояние Health
    /// </summary>
    private float CurrentHealth;

    /// <summary>
    /// Текущее значение, например, текущее состояние Mana
    /// </summary>
    private float CurrentMana;

    /// <summary>
    /// Значение для установки CurrentHealth и MaxHealth для health
    /// </summary>
    private float initHealph = 100;

    /// <summary>
    ///  Значение для установки CurrentMana и MaxMana для Mana
    /// </summary>
    private float initMana = 50;

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
        }
    }

    public float MyCurrentMana
    {
        get
        {
            return CurrentMana;
        }
        set
        {
            //Если CurrentValue становится больше Максимального значения
            if (value > MaxMana)
            {
                CurrentMana = MaxMana;
            }
            //Если CurrentValue меньше 0
            else if (value < 0)
            {
                CurrentMana = 0;
            }
            //Если CurrentValue меньше максимального значения и больше 0 
            else
            {
                CurrentMana = value;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponent<Stat>();
        //mana = GetComponent<Stat>();

        content = GetComponent<Image>();

        health.InitializeHealth(100, 100);
        mana.InitializeMana(50, 50);

    }


    void Update()
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
        DemoStat();
        Debug.Log(content.fillAmount);


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
    /// Устанавливает значение  CurrentMana(Текущее значение) и MaxMana(Макимальное значение) 
    /// </summary>
    public void InitializeMana(float maxValue, float currentValue)
    {
        MaxMana = maxValue;
        CurrentMana = currentValue;
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            mana.CurrentMana -= 10f;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {           
            mana.CurrentMana += 10f;
        }
    }
}
