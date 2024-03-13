using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotKillerControllerR : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();


    [SerializeField] private List<GameObject> final = new List<GameObject>();

    public GameControllerR gc;

    private GameObject lastCard = null;


    public GameObject losePanel;

    public bool isPlaused = false;

    public HelpeBtnsManager hmb;
    public SFXController sfx;
    public bool vibrations;

    public WinPanel wp = null;
    public WinPanelRandom wp2 = null;





    public Transform MoveToDesignedPosition(GameObject obj)
    {
        if (final.Count > 6)
        {
            losePanel.SetActive(true);
            return obj.transform;

        }
        else
        {
            int aux;
            final.Add(obj);
            aux = final.Count - 1;

            obj.GetComponent<PieceControllerRandon>().iIndex = aux;
            obj.GetComponent<PieceControllerRandon>().isP8 = false;
            obj.GetComponent<PieceControllerRandon>().locked = true;
            ;
            lastCard = obj;
            sfx.SetFX(0);
            SetStars();
            return positions[aux];
        }


    }




    public void check()
    {
        Dictionary<string, List<GameObject>> elementosPorNome = new Dictionary<string, List<GameObject>>();

        // Agrupa os elementos pelo _name
        foreach (GameObject obj in final)
        {
            string nome = obj.GetComponent<PieceControllerRandon>()._name;

            if (!elementosPorNome.ContainsKey(nome))
            {
                elementosPorNome[nome] = new List<GameObject>();
            }

            elementosPorNome[nome].Add(obj);
        }

        // Verifica se há pelo menos 3 elementos com o mesmo _name
        foreach (var kvp in elementosPorNome)
        {
            if (kvp.Value.Count >= 3)
            {
                // Desativa e remove os elementos da lista
                for (int i = 0; i < 3; i++)
                {
                    kvp.Value[i].GetComponent<PieceControllerRandon>().ActivePS();
                    kvp.Value[i].SetActive(false);
                    final.Remove(kvp.Value[i]);
                }
                gc.SetPoint();
                sfx.SetFX(1);
                if (SystemInfo.supportsVibration && vibrations)
                {
                    Handheld.Vibrate();
                }
            }
        }

        gc.CheckRemaingItens();
        Invoke("Realoc", .6f);
    }

    public void Realoc()
    {
        if (final.Count > 0)
        {
            foreach (GameObject p in final)
            {
                p.GetComponent<PieceControllerRandon>().realoc = positions[final.IndexOf(p)];
                p.GetComponent<PieceControllerRandon>().RealocPositions();
            }
            lastCard = final[final.Count - 1];
        }

    }

    public void SecondChance()
    {
        final[4].GetComponent<RemoveFronTheListRandom>().AddToList();
        final[4].GetComponent<PieceControllerRandon>().SetTimer();
        final[4].GetComponent<PieceControllerRandon>().isReturn = true;
        final[4].GetComponent<PieceControllerRandon>().isP8 = false;
        final[4].GetComponent<PieceControllerRandon>().isMove = false;
        final[4].GetComponent<PieceControllerRandon>().isMove2 = false;
        final[4].GetComponent<PieceControllerRandon>().locked = false;

        final[5].GetComponent<RemoveFronTheListRandom>().AddToList();
        final[5].GetComponent<PieceControllerRandon>().SetTimer();
        final[5].GetComponent<PieceControllerRandon>().isReturn = true;
        final[5].GetComponent<PieceControllerRandon>().isP8 = false;
        final[5].GetComponent<PieceControllerRandon>().isMove = false;
        final[5].GetComponent<PieceControllerRandon>().isMove2 = false;
        final[5].GetComponent<PieceControllerRandon>().locked = false;


        final[6].GetComponent<RemoveFronTheListRandom>().AddToList();
        final[6].GetComponent<PieceControllerRandon>().SetTimer();
        final[6].GetComponent<PieceControllerRandon>().isReturn = true;
        final[6].GetComponent<PieceControllerRandon>().isP8 = false;
        final[6].GetComponent<PieceControllerRandon>().isMove = false;
        final[6].GetComponent<PieceControllerRandon>().isMove2 = false;
        final[6].GetComponent<PieceControllerRandon>().locked = false;


        final.RemoveAt(6);
        final.RemoveAt(5);
        final.RemoveAt(4);



    }

    public void ReturCard()
    {
        if (hmb.ReturnHint() == true && lastCard != null)
        {
            final.Remove(lastCard);
            lastCard.GetComponent<RemoveFronTheListRandom>().AddToList();
            lastCard.GetComponent<PieceControllerRandon>().SetTimer();
            lastCard.GetComponent<PieceControllerRandon>().isReturn = true;
            lastCard.GetComponent<PieceControllerRandon>().isP8 = false;
            lastCard.GetComponent<PieceControllerRandon>().isMove = false;
            lastCard.GetComponent<PieceControllerRandon>().locked = false;

            sfx.SetFX(2);
            if (final.Count == 0)
            {
                lastCard = null;
            }
            else
            {
                lastCard = final[final.Count - 1];
            }
        }





    }

    public void MoveToP8()
    {
        if (hmb.ExtraSlotHint() == true && lastCard != null)
        {
            final.Remove(lastCard);
            lastCard.GetComponent<PieceControllerRandon>().SetTimer();
            lastCard.GetComponent<PieceControllerRandon>().isMove = false;
            lastCard.GetComponent<PieceControllerRandon>().isReturn = false;
            lastCard.GetComponent<PieceControllerRandon>().isP8 = true;
            lastCard.GetComponent<PieceControllerRandon>().locked = false;
            ;

            sfx.SetFX(5);
            if (final.Count == 0)
            {
                lastCard = null;
            }
            else
            {
                lastCard = final[final.Count - 1];
            }

        }



    }


    public void SetStars()
    {
        if (wp != null)
        {
            if (final.Count > 4)
            {
                wp.n1 = true;
            }

            if (final.Count > 6)
            {
                wp.n2 = true;
            }
        }
        else
        {
            if (final.Count > 4)
            {
                wp2.n1 = true;
            }

            if (final.Count > 6)
            {
                wp2.n2 = true;
            }
        }

    }
}
