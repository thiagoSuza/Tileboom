using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectBtn : MonoBehaviour
{
    public Button btn;

    public Text nv;

    public GameObject typeA, typeB;

    public GameObject[] stars;  

    public int index;

    public SetDesignedPanel stp;
   

    

   

    private void OnEnable()
    {
        btn = GetComponent<Button>();    
        

    }

   

    

    public void OpenLevel()
    {
        btn.interactable = true;
        typeA.SetActive(true);
        typeB.SetActive(false);
        int aux = PlayerPrefs.GetInt(index.ToString(),0);
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
        if(x == 1)
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
        PlayerPrefs.SetInt("Level", index);
        stp.LoadLevel();
       
       
    }

    

}
