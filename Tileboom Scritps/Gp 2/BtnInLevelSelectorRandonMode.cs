using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class BtnInLevelSelectorRandonMode : MonoBehaviour
{
     public Button btn;

    public Text nv;

    public GameObject typeA, typeB;

    public GameObject[] stars;

    

    public SetDesignedPanel stp;
    

    public int identify;
    public int chapter;

    public UnlockRandonLevel lv;




    

    private void OnEnable()
    {
        btn = GetComponent<Button>();
        
       
    }




    public void OpenLevel()
    {
        btn.interactable = true;
        typeA.SetActive(true);
        typeB.SetActive(false);
        int aux = PlayerPrefs.GetInt(identify.ToString(), 0);
        SetStar(aux);

    }

    public void CloseLevel()
    {
        btn.interactable = false;
        typeA.SetActive(false);
        typeB.SetActive(true);
    }



    public void SetStar(int x)
    {
        if (x == 1)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(false);
            stars[2].gameObject.SetActive(false);
        }

        if (x == 2)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(false);
        }

        if (x == 3)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(true);
        }
    }


    public void TestPlay()
    {
        PlayerPrefs.SetInt("Identify",identify);       
        PlayerPrefs.SetInt("Chapter",chapter);       
        stp.LoadRandom();


    }
}
