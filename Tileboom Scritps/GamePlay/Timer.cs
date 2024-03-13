using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public static Timer instance;

    private void Awake()
    {
        instance = this;
    }

    
    public float totalTime;

    [SerializeField]
    private Text timerText;

    public float currentTime;

    [SerializeField]
    private GameObject losePanel;

    public bool isRunning;

    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            if (isRunning)
            {
                currentTime -= Time.deltaTime;
            }
            


            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);


            timerText.text = formattedTime;
        }
        else  
        {

            isRunning = false;
            losePanel.SetActive(true);

        }


        float floatValue = 3.14159f;
        string formattedFloat = floatValue.ToString("0.00");

    }

    public void AddTimer()
    {
        currentTime += 20f;
    }
}
