using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Text wonTxt;
    public IdiomaController ic;
    [SerializeField]
    private GameObject[] stars;
    public SetLevel sl;

    public AdMobIntersticialBL ad;

    
    private int str = 3;

    public bool n1=false, n2=false;

    private void OnEnable()
    {
        wonTxt.text = ic.data[ic.index].vitoria;        
        sl.SetLelvelWon();
        SetStars();
        DesegneStars();
        sl.SaveStars(str);
        NextLevel();
        ad.ShowInterstitialAd();
        Timer.instance.isRunning = false;
    }
    

    public void NextLevel()
    {
        int index = PlayerPrefs.GetInt("Level", 0);
        index++;
        PlayerPrefs.SetInt("Level", index);
    }

   

    public void LoadNextLevel()
    {
        int index = PlayerPrefs.GetInt("Level", 0);
        if(index <= 49)
        {
            SceneManager.LoadScene("GamePlay");
        }
        else
        {
            SceneManager.LoadScene("GamePlay 2");
        }
        
    }


    public void SetStars()
    {
        if (n1)
        {
            str--;
        }

        if (n2)
        {
            str--;
        }
    }


    public void DesegneStars()
    {
        if(str == 1)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(false);
            stars[2].gameObject.SetActive(false);
        }

        if (str == 2)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(false);
        }

        if (str == 3)
        {
            stars[0].gameObject.SetActive(true);
            stars[1].gameObject.SetActive(true);
            stars[2].gameObject.SetActive(true);
        }
    }
}
