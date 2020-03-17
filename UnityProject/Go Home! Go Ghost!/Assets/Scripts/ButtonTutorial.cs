using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTutorial : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/Button").GetComponent<Button>();
        button.Select();
    }
}
