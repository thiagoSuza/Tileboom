using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBtnsData : MonoBehaviour
{
    
    public List<GameObject> pieces = new List<GameObject>();
   
    private int number;
    public NivelSO[] data;
    public Sprite[] n;
    private int index;

    private void Awake()
    {
        index = PlayerPrefs.GetInt("Level", 0);
        n = data[index].imgs;
       
    }
    void Start()
    {
       
        Invoke("SetElements", .2f);
    }

    public void GetNumber()
    {
        
        number =  pieces.Count / n.Length;
    }

    public void SetElements()
    {
        GetNumber();
        for (int j  = 0; j < n.Length; j++)
        {
            for (int i = 0; i <number; i++)
            {
                int aux = Random.Range(0, pieces.Count);               
                pieces[aux].GetComponent<PieceController>().SetSpriteAndName(n[j], n[j].name);
                pieces.RemoveAt(aux);
            }

        }
        
    }
}   
