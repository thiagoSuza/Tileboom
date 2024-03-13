using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemePanel : MonoBehaviour
{
    [SerializeField]
    private Text tittle;
    public SetTheme st;
    public LenguagemInUse lpc;


    private void OnEnable()
    {
        tittle.text = lpc.data[lpc.index].tema;
    }

    public void SetA()
    {
        st.SetThemeA();
        gameObject.SetActive(false);
    }

    public void SetB()
    {
        st.SetThemeB();
        gameObject.SetActive(false);
    }
}
