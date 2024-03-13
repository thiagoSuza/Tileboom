using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioClip[] musics;
    // Start is called before the first frame update
   

    public void SetFX(int x)
    {
        
        aud.PlayOneShot(musics[x]);
    }
}
