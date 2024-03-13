using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialScene : MonoBehaviour
{
    private void Awake()
    {
        Timer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Timer()
    {
        SceneManager.LoadScene(1);
    }
}
