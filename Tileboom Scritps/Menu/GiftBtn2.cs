using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBtn2 : MonoBehaviour
{
   
    public float tempoEsperaEmHoras = 1;
    public Image imagemPresente;
    public Text textoTemporizador;
    public Button btn;
    private DateTime ultimaVezPressionado;

    public BalanceManager bm;

    void Start()
    {
        // Carrega a última vez que o botão foi pressionado do PlayerPrefs.
        string ultimaVezPressionadoString = PlayerPrefs.GetString("UltimaVezPressionado2", "");
        if (!string.IsNullOrEmpty(ultimaVezPressionadoString))
        {
            ultimaVezPressionado = DateTime.Parse(ultimaVezPressionadoString);
        }

        AtualizarVisual();
    }

    void Update()
    {
        AtualizarVisual();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void AtualizarVisual()
    {
        // Calcula o tempo restante até o próximo presente.
        TimeSpan tempoRestante = ultimaVezPressionado.AddHours(tempoEsperaEmHoras) - DateTime.Now;

        if (tempoRestante.TotalSeconds > 0)
        {
            // Se o tempo estiver correndo, desativa a imagem e ativa o elemento de texto.
            imagemPresente.gameObject.SetActive(false);
            textoTemporizador.gameObject.SetActive(true);

            btn.interactable = false;
            textoTemporizador.text = string.Format("{0:hh\\:mm\\:ss}", tempoRestante);
        }
        else
        {
            btn.interactable = true;
            imagemPresente.gameObject.SetActive(true);
            textoTemporizador.gameObject.SetActive(false);
        }
    }

    public void DarPresente()
    {
        if (DateTime.Now >= ultimaVezPressionado.AddHours(tempoEsperaEmHoras))
        {
            int x = UnityEngine.Random.Range(1, 6);
            bm.AddESlot(x);
            bm.AddFire(x);
            bm.AddMap(x);
            bm.AddReturn(x);

            ultimaVezPressionado = DateTime.Now;
            PlayerPrefs.SetString("UltimaVezPressionado2", ultimaVezPressionado.ToString());
            PlayerPrefs.Save();
        }
        else
        {
            
        }
    }
}
