
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetRandomLevel : MonoBehaviour
{
    public GameControllerR gcr;
   
    public List<GameObject> positionsList;
    public List<GameObject> prefabs;


    [SerializeField]
    private Text nv;

    public IdiomaController controller;


    public List<GameObject> pieces = new List<GameObject>();

    private int number;

    public Sprite[] total;
    public Sprite[] n;

    private int _identify;
    private int pieceAmount;
   



    private void Awake()
    {

        SetElements();

    }

    

    private void Start()
    {
        _identify = PlayerPrefs.GetInt("Identify",50 );
        nv.text = _identify.ToString() + " " + controller.data[controller.index].niveis;
    }

    public void SetLelvelWon()
    {
        int y = PlayerPrefs.GetInt("SecondLevel", 0);
        if (_identify -50 >= y)
        {
            y = _identify -50+ 1;
            PlayerPrefs.SetInt("SecondLevel", y);
        }


    }



    public void SaveStats(int x)
    {
        PlayerPrefs.SetInt(_identify.ToString(), x);
    }
    

    public void SetElements()
    {
         pieceAmount = Random.Range(5,10);
         gcr.SetData(pieceAmount);
        InstantieteElements(pieceAmount);
    }

   public void InstantieteElements(int x)
    {
       for(int i = 0;i <= pieceAmount; i++)
        {
            int index = Random.Range(0,prefabs.Count);
            for (int j = 0;j < 3; j++)
            {
                int aux = Random.Range(0,positionsList.Count);
                GameObject obj = Instantiate(prefabs[index], transform.position, transform.rotation);
                obj.transform.parent = positionsList[aux].transform;
                obj.transform.localPosition = new Vector3(0, 0, -2);
                positionsList[aux].GetComponent<SetLayerIndex>().Action();
                positionsList.RemoveAt(aux);

            }

            prefabs.RemoveAt(index);
        }

    }

}
