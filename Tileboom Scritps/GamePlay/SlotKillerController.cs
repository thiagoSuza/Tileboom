using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SlotKillerController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();        
   

    [SerializeField] private List<GameObject> final = new List<GameObject>();

    public GameController gc;

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
        if (final.Count>6)
        {
            losePanel.SetActive(true);
            return obj.transform;           

        }
        else
        {
            int aux;
            final.Add(obj);
            aux = final.Count -1;
           
            obj.GetComponent<PieceController>().iIndex = aux;
            obj.GetComponent<PieceController>().isP8 = false;
            obj.GetComponent<PieceController>().locked = true;
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
            string nome = obj.GetComponent<PieceController>()._name;

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
                for (int i = 0; i <3; i++)
                {
                    kvp.Value[i].GetComponent<PieceController>().ActivePS();
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
        Invoke("Realoc",.6f);
    }

    public void Realoc()
    {
        if(final.Count > 0)
        {
            foreach (GameObject p in final)
            {
                p.GetComponent<PieceController>().realoc = positions[final.IndexOf(p)];
                p.GetComponent<PieceController>().RealocPositions();
            }
            lastCard = final[final.Count - 1];
        }
       
    }

    public void SecondChance()
    {
        final[4].GetComponent<RemoveFrontList>().AddToList();
        final[4].GetComponent<PieceController>().SetTimer();
        final[4].GetComponent<PieceController>().isReturn = true;
        final[4].GetComponent<PieceController>().isP8 = false;
        final[4].GetComponent<PieceController>().isMove = false;
        final[4].GetComponent<PieceController>().isMove2 = false;
        final[4].GetComponent<PieceController>().locked = false;

        final[5].GetComponent<RemoveFrontList>().AddToList();
        final[5].GetComponent<PieceController>().SetTimer();
        final[5].GetComponent<PieceController>().isReturn = true;
        final[5].GetComponent<PieceController>().isP8 = false;
        final[5].GetComponent<PieceController>().isMove = false;
        final[5].GetComponent<PieceController>().isMove2 = false;
        final[5].GetComponent<PieceController>().locked = false;


        final[6].GetComponent<RemoveFrontList>().AddToList();
        final[6].GetComponent<PieceController>().SetTimer();
        final[6].GetComponent<PieceController>().isReturn = true;
        final[6].GetComponent<PieceController>().isP8 = false;
        final[6].GetComponent<PieceController>().isMove = false;
        final[6].GetComponent<PieceController>().isMove2 = false;
        final[6].GetComponent<PieceController>().locked = false;


        final.RemoveAt(6);
        final.RemoveAt(5);
        final.RemoveAt(4);



    }

    public void ReturCard()
    {
        if(hmb.ReturnHint() == true && lastCard != null)
        {
            final.Remove(lastCard);
            lastCard.GetComponent<RemoveFrontList>().AddToList();
            lastCard.GetComponent<PieceController>().SetTimer();
            lastCard.GetComponent<PieceController>().isReturn = true;
            lastCard.GetComponent<PieceController>().isP8 = false;
            lastCard.GetComponent<PieceController>().isMove = false;
            lastCard.GetComponent<PieceController>().locked = false;
            
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
        if(hmb.ExtraSlotHint() == true && lastCard != null)
        {
            final.Remove(lastCard);
            lastCard.GetComponent<PieceController>().SetTimer();
            lastCard.GetComponent<PieceController>().isMove = false;
            lastCard.GetComponent<PieceController>().isReturn = false;
            lastCard.GetComponent<PieceController>().isP8 = true;
            lastCard.GetComponent<PieceController>().locked = false;
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
        if(wp != null)
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
    

    

