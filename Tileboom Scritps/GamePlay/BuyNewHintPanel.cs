using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewHintPanel : MonoBehaviour
{

    public SlotKillerController skc; 
    public SlotKillerControllerR killer;
    [SerializeField] private Text hintText;
    public IdiomaController ic;
    public HelpeBtnsManager helpeBtnsManager;
    [SerializeField] private int _balance;

    public int indice;

    [SerializeField]
    private GameObject[] spt; 
   

    private void OnEnable()
    {
        _balance = PlayerPrefs.GetInt("Gold", 300);
        if (skc != null)
        {
            skc.isPlaused = true;
        }
        else
        {
            killer.isPlaused = true;
        }
        Timer.instance.isRunning = false;
        hintText.text = ic.data[ic.index].fraseBuyHint;
        SetSprite();
    }

    private void OnDisable()
    {
        if (skc != null)
        {
            skc.isPlaused = false;
        }
        else
        {
            killer.isPlaused = false;
        }
        Timer.instance.isRunning = true;
    }

    public void SetSprite()
    {
        foreach(GameObject p in spt)
        {
            p.SetActive(false);
        }

        spt[indice].SetActive(true);
    }


    public void Buy()
    {
        if(_balance >= 400) 
        {
            helpeBtnsManager.Reward(indice);
            _balance -= 400;
            PlayerPrefs.SetInt("Gold",_balance);
            helpeBtnsManager.UpdateBalance(_balance);
            Close();
        }
        
    }

    public void WatchVideo()
    {
        helpeBtnsManager.ShowAdd(indice);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
