﻿using PUser;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int CurrentLevel;

    #region Mono Behaviour
    private void Awake()
    {
        Instance = this;
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
    }
    private void Start()
    {
        InitGame(CurrentLevel);
    }
    #endregion
    #region Events and Actions
    public event Action<int> OnInitGame;
    public event Action OnStartGame;
    public event Action OnPauseGame;
    public event Action OnResumeGame;
    public event Action OnWinGame;
    public event Action OnLoseGame;

    public event Action<float> OnUpdateProgressLevel;
    public event Action OnUpdateGem;

    public void InitGame(int currentLevel)
    { 
        if (OnInitGame != null) 
            OnInitGame.Invoke(currentLevel);
        Invoke("StartGame", .5f);
    }
    public void StartGame()
    {
        if (OnStartGame != null)
            OnStartGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        if (OnPauseGame != null)
            OnPauseGame();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (OnResumeGame != null)
            OnResumeGame();
    }
    public void WinGame()
    {
        CurrentLevel++;
        if (UserRepository.User.Level < CurrentLevel)
        {
            UserRepository.User.Level = CurrentLevel;
        }
        if (OnWinGame != null)
            OnWinGame();
    }
    public void LoseGame()
    {
        if (OnLoseGame != null)
            OnLoseGame();
    }
    public void RestartGame()
    {
        InitGame(CurrentLevel);
    }
    public void NextGame()
    {
        InitGame(CurrentLevel);
    }
    public void UpdateProgressLevel(float percentage)
    {
        if (OnUpdateProgressLevel != null)
            OnUpdateProgressLevel.Invoke(percentage);
    }
    public void UpdateGem()
    {
        if (OnUpdateGem != null)
            OnUpdateGem();
    }
    #endregion
}
