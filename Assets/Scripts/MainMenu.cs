using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuBack;
    public GameObject Story;
    public GameObject Setting;

    public GameObject CheckMusic;
    public GameObject CheckSound;

    public Slider SliderMusic;
    public Slider SliderSound;

    public int isMusic = 0;
    public int isSouond = 0;

    public float musicVolume = 1;
    public float souondVolume = 1;

    void Start()
    {
        CheckMusic.SetActive(true);
        CheckSound.SetActive(true);

        SliderMusic.onValueChanged.AddListener(delegate { MusicValueChange(); });
        SliderSound.onValueChanged.AddListener(delegate { SoundValueChange(); });
    }
    public void BtnStory()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Close");
        Invoke("OpenStory", 1.5f);
    }

    public void BtnSetting()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Close");
        Invoke("OpenSetting", 1.5f);
    }

    public void BtnBack(int num)
    {
        switch (num)
        {
            case 0:
                Debug.Log("ad");
                Story.GetComponent<Animator>().SetTrigger("Close");
                Invoke("OpenMenuBack", 1.5f);
                break;
            case 1:
                Setting.GetComponent<Animator>().SetTrigger("Close");
                Invoke("OpenMenuBack", 1.5f);
                break;

        }
    }

    void OpenStory()
    {
        Story.SetActive(true);
        Story.GetComponent<Animator>().SetTrigger("Open");
    }

    void OpenSetting()
    {
        Setting.SetActive(true);
        Setting.GetComponent<Animator>().SetTrigger("Open");
    }

    void OpenMenuBack()
    {
        MenuBack.GetComponent<Animator>().SetTrigger("Open");
    }

    public void BtnMusic()
    {
        CheckMusic.SetActive(!CheckMusic.activeInHierarchy);
    }
    public void BtnSound()
    {
        CheckSound.SetActive(!CheckSound.activeInHierarchy);
    }

    void MusicValueChange()
    {
        Debug.Log(SliderMusic.value);
    }
    void SoundValueChange()
    {
        Debug.Log(SliderSound.value);
    }
}
