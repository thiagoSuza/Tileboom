using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "1 Idioma", menuName = "ScriptableObjects/Idioma")]
public class LenguagemSO : ScriptableObject
{
    public string tema;
    public string continuar,reiniciar,inicio,tutorial,niveis;
    public string frase;
    public string fraseTimeOut;
    public string fraseBuyHint;
    public string vitoria;
    
}
