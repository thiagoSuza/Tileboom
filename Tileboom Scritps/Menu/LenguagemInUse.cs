using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguagemInUse : MonoBehaviour
{
    public LenguagemSO[] data;

    public int index;

    public Text nivel;

    private void Start()
    {
        
        index = PlayerPrefs.GetInt("Idioma", 1);
        nivel.text= data[index].niveis;
       
    }

   public void SetIdioma(int _value)
   {
        index = _value;

   }

    public void ReloadNivel()
    {
        nivel.text = data[index].niveis;
    }

   
}
