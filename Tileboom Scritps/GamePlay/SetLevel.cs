using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    public NivelSO[] data;
    [SerializeField]
    private GameObject[] g1; 
  

    [SerializeField]
    private Text nv;

    public IdiomaController controller;
    

    public int index;

    private void Awake()
    {
        index = PlayerPrefs.GetInt("Level", 0);
        g1[index].SetActive(true);
       
       
    }

    private void Start()
    {
        Timer.instance.totalTime = data[index].tempo;
        Timer.instance.isRunning = true;
        nv.text = index.ToString() + " " + controller.data[controller.index].niveis;
    }


    public void SetLelvelWon()
    {
        int y = PlayerPrefs.GetInt("FirstLevel", 0);
        if(index >= y)
        {
            y = index + 1;
            PlayerPrefs.SetInt("FirstLevel", y);
        }
        
            
    }

    public void SaveStars(int x)
    {
        PlayerPrefs.SetInt(index.ToString(),x);
    }
    
}
