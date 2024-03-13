using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositions : MonoBehaviour
{

    public static ChangePositions instance;
    public SFXController controller;
    public List<GameObject> l1 = new List<GameObject>();
    public List<GameObject> l2 = new List<GameObject>();
    public List<GameObject> l3 = new List<GameObject>();

    public HelpeBtnsManager hmb;

    private void Awake()
    {
        instance = this;
    }

    public void Embaralhar()
    {
        if (hmb.MapHint() == true)
        {
            L1();
            L2();
            L3();
            controller.SetFX(4);
        }
       
    }


    public void L1()
    {
        int quantidadeDePecas = l1.Count;

        // Itere sobre os objetos e troque suas posições aleatoriamente
        for (int i = quantidadeDePecas - 1; i > 0; i--)
        {
            int indiceAleatorio = Random.Range(0, i + 1);

            // Troque as posições no cenário
            Vector3 posicaoTemp = l1[i].transform.position;
            l1[i].transform.position = l1[indiceAleatorio].transform.position;
            l1[indiceAleatorio].transform.position = posicaoTemp;
        }
    }


    public void L2()
    {
        int quantidadeDePecas = l2.Count;

        // Itere sobre os objetos e troque suas posições aleatoriamente
        for (int i = quantidadeDePecas - 1; i > 0; i--)
        {
            int indiceAleatorio = Random.Range(0, i + 1);

            // Troque as posições no cenário
            Vector3 posicaoTemp = l2[i].transform.position;
            l2[i].transform.position = l2[indiceAleatorio].transform.position;
            l2[indiceAleatorio].transform.position = posicaoTemp;
        }
    }

    public void L3()
    {
        int quantidadeDePecas = l3.Count;

        // Itere sobre os objetos e troque suas posições aleatoriamente
        for (int i = quantidadeDePecas - 1; i > 0; i--)
        {
            int indiceAleatorio = Random.Range(0, i + 1);

            // Troque as posições no cenário
            Vector3 posicaoTemp = l3[i].transform.position;
            l3[i].transform.position = l3[indiceAleatorio].transform.position;
            l3[indiceAleatorio].transform.position = posicaoTemp;
        }
    }

    public void Add(int x,GameObject aux)
    {
        if(x == 1)
        {
            l1.Add(aux);
        }else if(x == 2)
        {
            l2.Add(aux);
        }
        else
        {
            l3.Add(aux);
        }
    }

    public void Remove(int x, GameObject aux)
    {
        if (x == 1)
        {
            l1.Remove(aux);
        }
        else if (x == 2)
        {
            l2.Remove(aux);
        }
        else
        {
            l3.Remove(aux);
        }
    }

}
