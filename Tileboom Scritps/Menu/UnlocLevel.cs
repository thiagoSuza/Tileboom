using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnlocLevel : MonoBehaviour
{

    public GameObject[] btns;
    public NivelSO[] data; 

    private void OnEnable()
    {
        


        for (int i = 0; i< btns.Length; i++)
        {
            btns[i].GetComponent<LevelSelectBtn>().index = data[i].index;
            btns[i].GetComponent<LevelSelectBtn>().nv.text = data[i].index.ToString();
        }


        foreach(var t in btns)
        {
            t.GetComponent<LevelSelectBtn>().CloseLevel();
        }

       int x = PlayerPrefs.GetInt("FirstLevel", 0)+1;
        if (x > btns.Length)
        {
            x=btns.Length;
        } 

        for (int i = 0; i < x; i++)
        {
            btns[i].GetComponent<LevelSelectBtn>().OpenLevel(); 
        }
    }
}
