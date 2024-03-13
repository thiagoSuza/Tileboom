using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetDesignedPanel : MonoBehaviour
{
    public Text title;

    public GameObject[] array;
    private int index = 0;
    private int idioma;
    [SerializeField]
    private LenguagemSO[] data;

    public GameObject rotater;


    [SerializeField]
    private GameObject loadingPanel;

    private int indexOFLevel;

    private string leve;

    public UnlockRandonLevel[] lvs;


    private int number = 50;
    private int _chapter = 0;



    private void Start()
    {
        idioma = PlayerPrefs.GetInt("Idioma", 1);
        SetText();
        SetNames();
       
        UnlockData();


    }

    private void Update()
    {
        rotater.transform.Rotate(0, 0, 0.7f);
    }

    public void SetNames()
    {
       for(int i = 0; i <lvs.Length; i++)
       {
            for (int j = 0; j < 50; j++)
            {
                lvs[i].btns[j].GetComponent<BtnInLevelSelectorRandonMode>().nv.text = number.ToString();
                lvs[i].btns[j].GetComponent<BtnInLevelSelectorRandonMode>().identify = number;
                lvs[i].btns[j].GetComponent<BtnInLevelSelectorRandonMode>().CloseLevel();
                number++;
            }
       }
    }

    public void UnlockData()
    {
      List<GameObject>  auxList = new List<GameObject>();
        int auxL = PlayerPrefs.GetInt("SecondLevel", 0) + 1;
      
        for (int i = 0; i < lvs.Length; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                auxList.Add(lvs[i].btns[j]);
                
            }
        }

        for (int i = 0; i < auxL; i++)
        {
            auxList[i].GetComponent<BtnInLevelSelectorRandonMode>().OpenLevel();
        }

        if (PlayerPrefs.GetInt("FirstLevel", 0) != 49)
        {
            lvs[0].btns[0].GetComponent<BtnInLevelSelectorRandonMode>().CloseLevel();

        }
        else
        {
            lvs[0].btns[0].GetComponent<BtnInLevelSelectorRandonMode>().OpenLevel();
        }
    }



   

   public void LoadLevel()
    {
        indexOFLevel = PlayerPrefs.GetInt("Level", 0);
        if (indexOFLevel <= 50)
        {
            leve = "GamePlay";
        }
        else
        {
            leve = "GamePlay 2";
        }
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsyncOperation());
   }


    public void LoadRandom()
    {
        leve = "GamePlay 2";
        loadingPanel.SetActive(true);
        StartCoroutine(LoadAsyncOperation());
    }


    public void IndexUp()
    {
        if(index<array.Length-1)
        {
            index++;
            SetText();
            foreach (GameObject go in array)
            {
                go.SetActive(false);
            }

            array[index].SetActive(true);
            
        }
        

    }


    public void IndexDown()
    {
        if(index>0)
        {
            index--;
            SetText();
            foreach (GameObject go in array)
            {
                go.SetActive(false);
            }

            array[index].SetActive(true);
        }
        

    }

    public void SetText()
    {
        title.text = data[idioma].niveis +": "+ (index + 1).ToString();
    }

    public void LoadSceneA()
    {
        SceneManager.LoadScene(1);
    }


    IEnumerator LoadAsyncOperation()
    {


        // Crie uma operação de carregamento assíncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(leve);

        // Mantenha a cena de carregamento ativa enquanto a cena alvo não estiver completamente carregada
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
           
            // Aguarde um frame antes de verificar novamente
            yield return null;

            // Se o carregamento estiver quase completo (0.9), permita a ativação da cena
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }

   
}
