using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguagemPanelController : MonoBehaviour
{
   

    public int index;
    public LenguagemInUse lpc;
    [SerializeField]
    private Image[] img;

    private void Start()
    {
        gameObject.SetActive(true);
        index = PlayerPrefs.GetInt("Idioma", 0);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        index = PlayerPrefs.GetInt("Idioma", 0);
        foreach (var item in img)
        {
            item.color = Color.green;
        }

        img[index].color = Color.white;
    }

    public void SetIndex(int _index)
    {
        index = _index;
        foreach (var item in img)
        {
            item.color = Color.green;
        }
        img[index].color = Color.white;
        PlayerPrefs.SetInt("Idioma", index);
        lpc.SetIdioma(index);
        lpc.ReloadNivel();
        
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
