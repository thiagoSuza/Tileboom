using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanelRandom : MonoBehaviour
{
    [SerializeField] private Text wonTxt;
    public IdiomaController ic;
    [SerializeField]
    private GameObject[] stars;
    public SetRandomLevel sl;

    public AdMobIntersticialBL ad;
    private int str = 3;

    public bool n1 = false, n2 = false;

    private void OnEnable()
    {
        wonTxt.text = ic.data[ic.index].vitoria;
        sl.SetLelvelWon();
        NextLevel();              
        SetStars();
        sl.SaveStats(str);
        DesegneStars();
        ad.ShowInterstitialAd();
        Timer.instance.isRunning = false;

    }


    public void NextLevel()
    {
        int index = PlayerPrefs.GetInt("Identify", 50);
        index++;
        PlayerPrefs.SetInt("Identify", index);


    }

   

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("GamePlay 2");
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
        if (str == 1)
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
