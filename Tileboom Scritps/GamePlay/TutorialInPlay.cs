using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInPlay : MonoBehaviour
{
    public IdiomaController controller;
    public Text txt;
  

    private void Start()
    {
        txt.text = controller.data[controller.index].tutorial;
    }

}
