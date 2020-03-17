using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectedOnTitle : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/Button/StartButton").GetComponent<Button>();
        button.Select();
    }
}
