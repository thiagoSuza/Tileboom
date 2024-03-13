using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsPanelInGame : MonoBehaviour
{
    public IdiomaController ic;
    [SerializeField]
    private Text continueTxt, reloadTxt, hometxt, tutorialtxt, niveistxt;


    [SerializeField] private AudioMixer mixer;

    [SerializeField] private GameObject imgMusicOn, imgMusicOff;
    [SerializeField] private GameObject imgSfxOn, imgSfxOff;
    [SerializeField] private GameObject vbrOn, vbrOff;

    private bool musicOn, sfxOn,vbr;

    public SlotKillerController skc;
    public SlotKillerControllerR killer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        SetLoadData();
        continueTxt.text = ic.data[ic.index].continuar;
        reloadTxt.text = ic.data[ic.index].reiniciar;
        hometxt.text = ic.data[ic.index].inicio;       
        niveistxt.text = ic.data[ic.index].niveis;
        if(skc != null)
        {
            skc.isPlaused = true;
        }
        else
        {
            killer.isPlaused = true;
        }
       
    }

    private void OnDisable()
    {
        if (skc != null)
        {
            skc.isPlaused = false;
        }
        else
        {
            killer.isPlaused = false;
        }
        
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void ReturntToHome()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Niveis()
    {
        SceneManager.LoadScene("Level");
    }

    public void ReloadScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void SetLoadData()
    {
        if (PlayerPrefs.GetInt("MUSIC2", 0) == 0)
        {
            musicOn = true;
            mixer.SetFloat("MUSIC", 0);
            imgMusicOn.SetActive(true);
            imgMusicOff.SetActive(false);
        }
        else
        {
            musicOn = false;
            mixer.SetFloat("MUSIC", -80);
            imgMusicOn.SetActive(false);
            imgMusicOff.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SFX2", 0) == 0)
        {
            sfxOn = true;
            mixer.SetFloat("SFX", 0);
            imgSfxOn.SetActive(true);
            imgSfxOff.SetActive(false);
        }
        else
        {
            sfxOn = false;
            mixer.SetFloat("SFX", -80);
            imgSfxOn.SetActive(false);
            imgSfxOff.SetActive(true);
        }

        if(PlayerPrefs.GetInt("Vbr",0) == 0)
        {
            vbrOn.SetActive(true);
            vbrOff.SetActive(false);
            vbr = true;
            skc.vibrations = true;
        }
        else
        {
            vbrOn.SetActive(false);
            vbrOff.SetActive(true);
            vbr = false;
            skc.vibrations = false;
        }
    }

    public void SetMusicOn()
    {
        if (!musicOn)
        {
            mixer.SetFloat("MUSIC", 0);
            imgMusicOn.SetActive(true);
            imgMusicOff.SetActive(false);
            musicOn = true;
            PlayerPrefs.SetInt("MUSIC2", 0);
        }
        else
        {
            mixer.SetFloat("MUSIC", -80);
            imgMusicOn.SetActive(false);
            imgMusicOff.SetActive(true);
            musicOn = false;
            PlayerPrefs.SetInt("MUSIC2", 1);
        }

    }


    public void SetSFXOn()
    {
        if (!sfxOn)
        {
            mixer.SetFloat("SFX", 0);
            imgSfxOn.SetActive(true);
            imgSfxOff.SetActive(false);
            sfxOn = true;
            PlayerPrefs.SetInt("SFX2", 0);
        }
        else
        {
            mixer.SetFloat("SFX", -80);
            imgSfxOn.SetActive(false);
            imgSfxOff.SetActive(true);
            sfxOn = false;
            PlayerPrefs.SetInt("SFX2", 1);

        }
    }

    public void Vibration()
    {
        if (!vbr)
        {
            
            vbrOn.SetActive(true);
            vbrOff.SetActive(false);
            vbr = true;
            PlayerPrefs.SetInt("Vbr", 0);
            skc.vibrations = true;
        }
        else
        {
            
            vbrOn.SetActive(false);
            vbrOff.SetActive(true);
            vbr = false;
            PlayerPrefs.SetInt("Vbr", 1);
            skc.vibrations = false;

        }
    }

}
