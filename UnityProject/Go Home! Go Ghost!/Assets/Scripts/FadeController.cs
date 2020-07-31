using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    const float fadeSpeed = 0.01f;
    const float fadeInTime = 0.0f;
    const float fadeOutTime = 1.0f;
    float red, green, blue, alfa;

    public bool isFadeOut = false;
    public bool isFadeIn = false;

    Image fadeImage;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;
        SetAlfa();
        if(alfa <= fadeInTime)
        {
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();
        if(alfa >= fadeOutTime)
        {
            isFadeOut = false;
        }
    }

    void SetAlfa()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
