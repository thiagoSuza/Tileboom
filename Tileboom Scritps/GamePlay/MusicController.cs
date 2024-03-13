using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource aud;
    [SerializeField] private AudioClip[] musics;
    // Start is called before the first frame update
    void Start()
    {
        SetMusic();
    }

    public void SetMusic()
    {
        int x = Random.Range(0, musics.Length);
        aud.PlayOneShot(musics[x]);
    }
}
