﻿using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject settings;
    public GameObject settingsButton;
    public GameObject interfaceSettings;
    public static bool firstPlay;
    public static bool firstRun;
    private int level;

    private AudioManager audioManager;
    void Start()
    { 
        if(File.Exists(Application.persistentDataPath + "/settings.bin"))
        {
            Debug.Log(1);
            firstRun = false;
        }
        else
        {
            Debug.Log(2);
            firstRun = true;
        }

        level = SaveSystem.LoadChar().level;
        settings.SetActive(false);
        settingsButton.SetActive(true);
        interfaceSettings.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Theme");
    }

    public void NewGame()
    {
        audioManager.Play("ClickUI");
        firstPlay = true;
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        audioManager.Play("ClickUI");
        firstPlay = false;
        SceneManager.LoadScene("Game");
    }

    public void LinkToVk()
    {
        audioManager.Play("ClickUI");
        Application.OpenURL("https://vk.com/arazorg");
    }

    public void LinkToTwitter()
    {
        audioManager.Play("ClickUI");
        Application.OpenURL("https://twitter.com/arazorg");
    }

    public void SettingsPanelOpen()
    {
        audioManager.Play("ClickUI");
        if (settingsButton.activeSelf == true)
        {
            settings.SetActive(true);
            settingsButton.SetActive(false);
        }
    }

    public void ExitGame()
    {
        audioManager.Play("ClickUI");
        Application.Quit();
    }

}
