using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject pause;
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void ShowPause()
    {
        mainUI.SetActive(false);
        pause.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void ClosePause()
    {
        pause.SetActive(false);
        mainUI.SetActive(true);

        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("music") == "off"){
            var cameraAudioSource = Camera.main.GetComponent<AudioSource>();
            if (cameraAudioSource)
            {
                cameraAudioSource.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
