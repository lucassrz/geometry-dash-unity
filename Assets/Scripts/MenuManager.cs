using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource _audioSource;
    
    private void Start()
    {
        PlayThemeSong();
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void SettingsButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void HelpButton()
    {
        SceneManager.LoadScene(2);
    }
    
    public static void LevelListButton()
    {
        SceneManager.LoadScene(4);
    }

    public void LevelButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void PlayThemeSong()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = menu;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}