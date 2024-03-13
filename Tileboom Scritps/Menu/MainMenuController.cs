using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject store,idioma,gift,theme,credit,daily;

    [SerializeField]
    private GameObject rotater,rotater2;
    
    [SerializeField] private GameObject loadPanel,loadingPanel2;

    [SerializeField]
    private string urlPoliticaPrivacidade = "https://www.exemplo.com/politica-de-privacidade";

    public AdmobIntersticialStart admStar;

    private int indexOFLevel;

    private string leve;

    private void Update()
    {
        rotater.transform.Rotate(0, 0, 1f); 
        rotater2.transform.Rotate(0, 0, 1f); 
    }

    private void Start()
    {
        indexOFLevel = PlayerPrefs.GetInt("FirstLevel", 0);
        
        if (indexOFLevel < 49)
        {
            leve = "GamePlay";
        }
        else
        {
            leve = "GamePlay 2";
        }
    }

    public void OpenStore()
    {
        store.SetActive(true);
    }

    public void OpenIdioma()
    {
        idioma.SetActive(true);
    }

    public void OpenGift()
    {
        gift.SetActive(true);
    }

    public void OpenTheme()
    {
        theme.SetActive(true);
    }

    public void OpenDaily()
    {
        daily.SetActive(true);
    }

    public void TestPlay()
    {
        admStar.Action();
        loadPanel.SetActive(true);
        StartCoroutine(LoadAsyncOperation());
        
    }

    public void LoadNivel()
    {
        loadingPanel2.SetActive(true);
        StartCoroutine(LoadAsyncOperation2());
    }

    public void OpenCredit()
    {
        credit.SetActive(true);
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

    IEnumerator LoadAsyncOperation2()
    {


        // Crie uma operação de carregamento assíncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Level");
        
        // Mantenha a cena de carregamento ativa enquanto a cena alvo não estiver completamente carregada
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            rotater2.transform.Rotate(0, 0, 1f);

            // Aguarde um frame antes de verificar novamente
            yield return null;

            // Se o carregamento estiver quase completo (0.9), permita a ativação da cena
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }

    public void AbrirLinkPoliticaPrivacidade()
    {
        Application.OpenURL(urlPoliticaPrivacidade);
    }
}
