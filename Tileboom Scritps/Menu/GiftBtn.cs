using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBtn : MonoBehaviour
{
    [SerializeField]
    private int goldGiftAmount;
    [SerializeField]
    private float tempoEsperaEmHoras;
    public Text temporizadorText;
    public GameObject img;

    private Button presentButton;
    private DateTime ultimaVezPressionado;



    public BalanceManager bm;

    void Start()
    {
        presentButton = GetComponent<Button>();
        presentButton.onClick.AddListener(DarPresente);

        // Carrega a última vez que o botão foi pressionado do PlayerPrefs.
        string ultimaVezPressionadoString = PlayerPrefs.GetString("UltimaVezPressionado", "");
        if (!string.IsNullOrEmpty(ultimaVezPressionadoString))
        {
            ultimaVezPressionado = DateTime.Parse(ultimaVezPressionadoString);
        }
    }

    void Update()
    {
        AtualizarTemporizador();
    }

    void AtualizarTemporizador()
    {
        if (temporizadorText != null)
        {
            // Calcula o tempo restante até o próximo presente.
            TimeSpan tempoRestante = ultimaVezPressionado.AddHours(tempoEsperaEmHoras) - DateTime.Now;

            
            if (tempoRestante.TotalSeconds > 0)
            {
                temporizadorText.text = string.Format(" {0:hh\\:mm\\:ss}", tempoRestante);
                img.SetActive(false);
            }
            else
            {
                img.SetActive(true);
                temporizadorText.text = "";
            }
        }
    }

    void DarPresente()
    {
        if (DateTime.Now >= ultimaVezPressionado.AddHours(tempoEsperaEmHoras))
        {
            bm.AddGold(goldGiftAmount);

            ultimaVezPressionado = DateTime.Now;
            PlayerPrefs.SetString("UltimaVezPressionado", ultimaVezPressionado.ToString());
            PlayerPrefs.Save();
        }
        else
        {
           
        }
    }
}
