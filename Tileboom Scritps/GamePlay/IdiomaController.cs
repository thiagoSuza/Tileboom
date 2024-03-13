using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiomaController : MonoBehaviour
{
    public LenguagemSO[] data;
    public int index;
    // Start is called before the first frame update
    private void Awake()
    {
        index = PlayerPrefs.GetInt("Idioma", 1);
    }

   

   
}
