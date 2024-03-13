using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerR : MonoBehaviour
{

    [Header("Canvas")]
    [SerializeField] private Image img;
    [SerializeField] private Sprite sp1, sp2;
    [SerializeField] private Text numberOfObjectives;
    [SerializeField] private GameObject winPanel, optionsPanel;
    [Header("BTN")]
    public List<GameObject> btns = new List<GameObject>();
    [Header("OTHERS")]
    public HelpeBtnsManager hbm;
    public SlotKillerControllerR slotKillerController;
    public SetBtnsData type;
    public SetRandomLevel lv = null;
    public SFXController sfx;
    private int _3blocksAmount;


    void Start()
    {
       
        LoadDesignedTheme();


    }

   public void SetData(int aux)
    {
        _3blocksAmount = aux+1;
        numberOfObjectives.text = _3blocksAmount.ToString();

    }

    public void SetToListBtn(GameObject aux)
    {
        btns.Add(aux);
        if (type != null)
        {

            type.pieces.Add(aux);
        }
        else
        {
            lv.pieces.Add(aux);
        }

    }

    public void SetPoint()
    {
        _3blocksAmount--;
        numberOfObjectives.text = _3blocksAmount.ToString();

    }
    public void LoadDesignedTheme()
    {
        if (PlayerPrefs.GetInt("Theme", 0) == 0)
        {
            img.sprite = sp1;
        }
        else
        {
            img.sprite = sp2;
        }
    }


    public void AutoKillBtn()
    {
        if (hbm.Fire() == true)
        {
            sfx.SetFX(3);
            List<PieceControllerRandon> pieceControllers;
            pieceControllers = new List<PieceControllerRandon>(FindObjectsOfType<PieceControllerRandon>());
            string aux = pieceControllers[0]._name;

            foreach (PieceControllerRandon pieceController in pieceControllers)
            {
                if (pieceController._name == aux)
                {
                    pieceController.ActivePS();
                    pieceController.RemoveList();
                }
            }


            SetPoint();
            CheckRemaingItens();

        }

    }

    public void CheckRemaingItens()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (GameObject p in btns)
        {
            if (!p.activeInHierarchy)
            {
                list.Add(p);
            }


        }


        if (_3blocksAmount <= 0)
        {
            winPanel.SetActive(true);
        }


    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
}
