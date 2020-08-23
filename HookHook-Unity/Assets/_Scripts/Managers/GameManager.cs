using PUser;
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
    public event Action<int> OnUpdateCoin;

    public void InitGame(int currentLevel)
    {
        Debug.Log("init game with level:" + CurrentLevel);
        Invoke("StartGame", .5f);
        if (OnInitGame != null) 
            OnInitGame.Invoke(currentLevel);
    }
    public void StartGame()
    {
        Debug.Log("start game with level:" + CurrentLevel);
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
        if (CurrentLevel > 8)
            CurrentLevel = 8;
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
    public void UpdateCoin(int coinCount)
    {
        if (OnUpdateCoin != null)
            OnUpdateCoin.Invoke(coinCount);
    }
    #endregion
}
