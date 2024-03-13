using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HelpeBtnsManager : MonoBehaviour
{
    [SerializeField] private int returnAMount, fireAmount, mapAmount, extraSlotAmount;
    [SerializeField] private Text returnTxt,fireTxt,mapTxt,extrSlotTxt;
    [SerializeField] private Text goldAmountTxt;
    [SerializeField] private int _balance;

    [SerializeField] private BuyNewHintPanel bnhp;
    [SerializeField] private GameObject buyPanel;

    public ADMobHintReward adss;

    // Start is called before the first frame update
    void Start()
    {
        _balance = PlayerPrefs.GetInt("Gold", 300); 
        goldAmountTxt.text = _balance.ToString();
        SetData();
    }

    void SetData()
    {
        returnAMount = PlayerPrefs.GetInt("ReturnHint", 4);
        fireAmount = PlayerPrefs.GetInt("FireHint", 4);
        mapAmount = PlayerPrefs.GetInt("MapHint", 4);
        extraSlotAmount = PlayerPrefs.GetInt("ExtraSlotHint", 4);

        returnTxt.text = returnAMount.ToString();
        fireTxt.text = fireAmount.ToString();
        mapTxt.text = mapAmount.ToString();
        extrSlotTxt.text = extraSlotAmount.ToString();

        SetZero();
    }

   public bool Buy(int x)
   {
        if(_balance >= x)
        {
            _balance -= x;
            PlayerPrefs.SetInt("Gold",_balance);
            goldAmountTxt.text = _balance.ToString();
            return true;
        }
        else{
            return false;
        }
   }


    public void SetZero()
    {
        if (fireAmount == 0)
        {
            fireTxt.color = Color.yellow;
            fireTxt.text = "0";
        }

        if (returnAMount == 0)
        {
            returnTxt.color = Color.yellow;
            returnTxt.text = "0";
        }

        if (extraSlotAmount == 0)
        {
            extrSlotTxt.color = Color.yellow;
            extrSlotTxt.text = "0";
        }

        if (mapAmount == 0)
        {
            mapTxt.color = Color.yellow;
            mapTxt.text = "0";
        }
    }


    public bool Fire()
    {
        if(fireAmount > 0)
        {
            fireAmount--;
            PlayerPrefs.SetInt("FireHint", fireAmount);
            fireTxt.text = fireAmount.ToString();
            if(fireAmount == 0)
            {
                fireTxt.color = Color.yellow;
                fireTxt.text = "0";
            }
            return true;
        }
        else
        {
            bnhp.indice = 1;
            buyPanel.SetActive(true);
           
            return false;
        }
    }

    public bool ReturnHint()
    {
        if (returnAMount > 0)
        {
            returnAMount--;
            PlayerPrefs.SetInt("ReturnHint", returnAMount);
            returnTxt.text = returnAMount.ToString();
            if (returnAMount== 0)
            {
                returnTxt.color = Color.yellow;
                returnTxt.text = "0";
            }
            return true;
        }
        else
        {
            bnhp.indice = 0;
            buyPanel.SetActive(true);
            return false;
        }
    }

    public bool ExtraSlotHint()
    {
        if (extraSlotAmount > 0)
        {
            extraSlotAmount--;
            PlayerPrefs.SetInt("ExtraSlotHint", extraSlotAmount);
            extrSlotTxt.text = extraSlotAmount.ToString();
            if (extraSlotAmount == 0)
            {
                extrSlotTxt.color = Color.yellow;
                extrSlotTxt.text = "0";
            }
            return true;
        }
        else
        {
            bnhp.indice = 3;
            buyPanel.SetActive(true);
            return false;
        }
    }

    public bool MapHint()
    {
        if (mapAmount > 0)
        {
            mapAmount--;
            PlayerPrefs.SetInt("MapHint", mapAmount);
            mapTxt.text = mapAmount.ToString();
            if (mapAmount == 0)
            {
                mapTxt.color = Color.yellow;
                mapTxt.text = "0";
            }            
            return true;
        }
        else
        {
            bnhp.indice = 2;
            buyPanel.SetActive(true);
            return false;
        }
    }


    public void ShowAdd(int x)
    {
        adss.index = x;
        adss.ShowRewardedAd();
    }


    public void Reward(int x)
    {
        if(x == 0)
        {
            returnAMount++;
            PlayerPrefs.SetInt("ReturnHint", returnAMount);
            returnTxt.color = Color.white;
            returnTxt.text = returnAMount.ToString();
        }

        if (x == 1)
        {
            fireAmount++;
            PlayerPrefs.SetInt("FireHint", fireAmount);
            fireTxt.color = Color.white;
            fireTxt.text = fireAmount.ToString();
        }

        if (x == 2)
        {
            mapAmount++;
            PlayerPrefs.SetInt("MapHint", mapAmount);
            mapTxt.color = Color.white;
            mapTxt.text = mapAmount.ToString();
        }

        if (x == 3)
        {
            extraSlotAmount++;
            PlayerPrefs.SetInt("ExtraSlotHint", extraSlotAmount);
            extrSlotTxt.color = Color.white;
            extrSlotTxt.text = extraSlotAmount.ToString();
        }

        
    }

    public void UpdateBalance(int x)
    {
        goldAmountTxt.text = x.ToString();
    }

}
