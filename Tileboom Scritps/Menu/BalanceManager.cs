using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceManager : MonoBehaviour
{
    private int gold, returnAmount, fireAmount, mapAmount, extraSlotAmount;

    [SerializeField]
    private Text goldInMenu,goldInStore,returnTxt,fireTxt,mapTxt,extraSlotTxt;

    

    // Start is called before the first frame update
    void Start()
    {
        SetData();
    }

    

    public void SetData()
    {
        returnAmount = PlayerPrefs.GetInt("ReturnHint",1);
        fireAmount = PlayerPrefs.GetInt("FireHint", 1);
        mapAmount = PlayerPrefs.GetInt("MapHint", 1);
        extraSlotAmount = PlayerPrefs.GetInt("ExtraSlotHint", 1);
        gold = PlayerPrefs.GetInt("Gold", 300);

        goldInMenu.text = gold.ToString();
        goldInStore.text = gold.ToString();

        returnTxt.text = returnAmount.ToString();
        fireTxt.text = fireAmount.ToString();
        mapTxt.text = mapAmount.ToString();
        extraSlotTxt.text = extraSlotAmount.ToString();
    }

    public void AddReturn(int _value)
    {
        returnAmount+= _value;
        PlayerPrefs.SetInt("ReturnHint", returnAmount);
        returnTxt.text = returnAmount.ToString();
    }

    public void AddFire(int _value)
    {
        fireAmount += _value;
        PlayerPrefs.SetInt("FireHint", fireAmount);
        fireTxt.text = fireAmount.ToString();
    }

    public void AddMap(int _value)
    {
        mapAmount += _value;
        PlayerPrefs.SetInt("MapHint", mapAmount);
        mapTxt.text = mapAmount.ToString();
    }

    public void AddESlot(int _value)
    {
        extraSlotAmount += _value;
        PlayerPrefs.SetInt("ExtraSlotHint", extraSlotAmount);
        extraSlotTxt.text = extraSlotAmount.ToString();
    }

    public void AddGold(int _value)
    {
        gold += _value;
        PlayerPrefs.SetInt("Gold",gold );
        goldInMenu.text = gold.ToString();
        goldInStore.text = gold.ToString();
    }


}
