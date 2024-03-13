using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStorePanel : MonoBehaviour
{
    public BalanceManager bm;
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        bm.SetData();
       
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
