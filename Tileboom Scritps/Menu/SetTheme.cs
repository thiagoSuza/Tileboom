using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTheme : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Sprite[] sp1, sp2;

    void Start()
    {
        LoadDesignedTheme();


    }

    public void LoadDesignedTheme()
    {
        if(PlayerPrefs.GetInt("Theme", 0) == 0)
        {
            int x = Random.Range(0,sp1.Length);
            img.sprite = sp1[x];
        }
        else
        {
            int x = Random.Range(0, sp2.Length);
            img.sprite = sp2[x];
        }
    }

    public void SetThemeA()
    {
        int x = Random.Range(0, sp1.Length);
        img.sprite = sp1[x];
        PlayerPrefs.SetInt("Theme", 0);
    }

    public void SetThemeB()
    {
        int x = Random.Range(0, sp2.Length);
        img.sprite = sp2[x];
        PlayerPrefs.SetInt("Theme", 1);
    }
}
