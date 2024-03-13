using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nivel", menuName = "ScriptableObjects/Nivel")]
public class NivelSO : ScriptableObject
{
    public Sprite[] imgs;
    public int index;
    public float tempo;
   
    

   
    public void GetName()
    {
        string[] words = name.Split(' ');
        if (words.Length > 1)
        {
            if (int.TryParse(words[1], out int result))
            {
                index = result;
            }
        }
    }
}
