using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiTest : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Я кнопка"))
        {
            print("Вы нажали кнопку");
        }
    }

}
