using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanelR : MonoBehaviour
{
    [SerializeField] private Text frase;


    public IdiomaController ic;
    public SlotKillerControllerR skc;

    private void OnEnable()
    {
        frase.text = ic.data[ic.index].frase;
        skc.isPlaused = true;
        skc.SecondChance();
        Timer.instance.isRunning = false;
    }

    private void OnDisable()
    {
        skc.isPlaused = false;
        Timer.instance.isRunning = true;
    }

    public void PlayAgain()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void PayToReturn()
    {
        if (skc.hmb.Buy(350) == true)
        {
            skc.isPlaused = false;

            gameObject.SetActive(false);
        }
    }
}
