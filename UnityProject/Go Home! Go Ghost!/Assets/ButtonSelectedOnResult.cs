using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectedOnResult : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/totitle").GetComponent<Button>();
        button.Select();
    }

    public void ButtonSelect(bool select)
    {
        if (select)
        {
            button = GameObject.Find("Canvas/totitle").GetComponent<Button>();
            button.Select();
        }
    }
}
