﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject loginScreen;
    public AudioSource mainMenu;
    public void OnEnable()
    {
        Time.timeScale = 0;
        mainMenu.Play();
    }
    public void OnDisable()
    {
        Time.timeScale = 1;
    }
    
    public void PlayGame()
    {
        loginScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
