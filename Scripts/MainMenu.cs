using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject options;
    [SerializeField] GameObject musicButton;
    [SerializeField] GameObject audioButton;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void BackToMenu()
    {
        credits.SetActive(false);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ToggleMusic()
    {
        if (PlayerPrefs.GetString("music") == "off")
        {
            PlayerPrefs.SetString("music", "");
            musicButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            PlayerPrefs.SetString("music", "off");
            musicButton.GetComponent<Image>().sprite = soundOff;
        }
    }

    public void ToggleAudio()
    {
        if (PlayerPrefs.GetString("audio") == "off")
        {
            PlayerPrefs.SetString("audio", "");
            audioButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            PlayerPrefs.SetString("audio", "off");
            audioButton.GetComponent<Image>().sprite = soundOff;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("music") == "off")
        {
            musicButton.GetComponent<Image>().sprite = soundOff;
        } else
        {
            musicButton.GetComponent<Image>().sprite = soundOn;
        }

        if (PlayerPrefs.GetString("audio") == "off")
        {
            audioButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            audioButton.GetComponent<Image>().sprite = soundOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
