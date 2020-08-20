﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public Button Pause, Home;
    public GameObject WinView, LoseView, ProgressView, PauseView;

    private void Start()
    {
        GameManager.Instance.OnInitGame += OnInitGame;
        GameManager.Instance.OnWinGame += PopUpWin;
        GameManager.Instance.OnLoseGame += PopUpLose;
        GameManager.Instance.OnUpdateProgressLevel += OnUpdateProgress;
    }
    public void OnInitGame(int currentLevel)
    {
        WinView.SetActive(false);
        LoseView.SetActive(false);
        PauseView.SetActive(false);
        Home.gameObject.SetActive(false);   
        Pause.gameObject.SetActive(true);
        ProgressView.SetActive(true);

    }
    public void OnUpdateProgress(float percentage)
    {

    }
    public void PopUpWin()
    {
        WinView.SetActive(true);
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        ProgressView.SetActive(false);
    }
    public void PopUpLose()
    { 
        LoseView.SetActive(true);
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        ProgressView.SetActive(false);
    }
    public void PauseGame()
    {
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        PauseView.SetActive(true);
        GameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        Home.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
        PauseView.SetActive(false);
        GameManager.Instance.ResumeGame();
    }
}