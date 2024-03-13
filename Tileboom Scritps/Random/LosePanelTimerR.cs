using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LosePanelTimerR : MonoBehaviour
{
    public SlotKillerControllerR skc;
    [SerializeField] private Text hintText;
    public IdiomaController ic;

    private void OnEnable()
    {

        skc.isPlaused = true;
        hintText.text = ic.data[ic.index].fraseTimeOut;


    }

    private void OnDisable()
    {
        skc.isPlaused = false;
        Timer.instance.isRunning = true;
        Timer.instance.AddTimer();
    }

    public void Close()
    {
        gameObject.SetActive(false);
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
