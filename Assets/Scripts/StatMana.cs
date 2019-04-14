using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMana : MonoBehaviour
{    
    /// <summary>
    /// Мана
    /// </summary>
    [SerializeField]
    private StatMana mana;

    /// <summary>
    /// Это текст (100/100) который будет менятся 
    /// </summary>
    [SerializeField]
    private Text statValue;

    /// <summary>
    /// ссылка на изображение, которое будет заполнятся 
    /// </summary>
    private Image content;

    /// <summary>
    /// Скорость интерполяции
    /// </summary>
    [SerializeField]
    private float LerpSpeed;

    /// <summary>
    ///Текущее заполнение (в долях единиц) от 0 до 1
    /// </summary>
    private float CurrentFill;

    // <summary>
    /// Максимальное значение для Mana
    /// </summary>
    private float MaxMana { get; set; }

    /// <summary>
    /// Текущее значение, например, текущее состояние Mana
    /// </summary>
    private float CurrentMana;

    /// <summary>
    ///  Значение для установки CurrentMana и MaxMana для Mana
    /// </summary>
    [SerializeField]
    private float initMana = 50;

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
        //mana = GetComponent<Stat>();

        content = GetComponent<Image>();
      
        mana.InitializeMana(initMana, initMana);
    }


    void Update()
    {
        ChangeCurrenFill();
        ChangeStatValue();

        DemoStat();
    }

    /// <summary>
    /// Устанавливает значение  CurrentMana(Текущее значение) и MaxMana(Макимальное значение) 
    /// </summary>
    public void InitializeMana(float maxValue, float currentValue)
    {
        MaxMana = maxValue;
        CurrentMana = currentValue;
    }

    /// <summary>
    /// Изменяет текущее заполнение
    /// </summary>
    public void ChangeCurrenFill()
    {
        //Рассчитываем текущее заполнение(в долях), что бы мы могли его интерполировать
        CurrentFill = CurrentMana / MaxMana;

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
        statValue.text = CurrentMana + " / " + MaxMana;
    }

    public void DemoStat()
    {
        ///ЭТО ИСПОЛЬЗУЕТСЯ ЛИШЬ ДЛЯ ПРОВЕРКИ
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            mana.MyCurrentMana -= 10f;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            mana.MyCurrentMana += 10f;
        }
    }
}
