using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeScreen;
    private bool ShouldFadeToBlack, shouldFadeFromBlack;
    public float fadeSpeed;
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(ShouldFadeToBlack)
        {
            fadeScreen.color = 
                new Color(
                    fadeScreen.color.r,
                    fadeScreen.color.g,
                    fadeScreen.color.b,
                    Mathf.MoveTowards(
                        fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime)
                    );

            if(fadeScreen.color.a == 1f)
            {
                ShouldFadeToBlack = false;
            }
        }
        
        if(shouldFadeFromBlack)
        {
            fadeScreen.color = 
                new Color(
                    fadeScreen.color.r,
                    fadeScreen.color.g,
                    fadeScreen.color.b,
                    Mathf.MoveTowards(
                        fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime)
                    );

            if(fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        ShouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        ShouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
