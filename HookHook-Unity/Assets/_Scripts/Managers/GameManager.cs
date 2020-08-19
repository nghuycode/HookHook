using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool CanPlay;
    public bool IsWin;
    public int CurrentLevel;

    #region Mono Behaviour
    private void Awake()
    {
        Instance = this;
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
    public event Action OnWinGame;
    public event Action OnLoseGame;
    public event Action OnNextGame;

    public event Action<float> OnUpdateProgressLevel;
    public event Action OnUpdateGem;
    public void InitGame(int currentLevel)
    {
        if (OnInitGame != null) 
            OnInitGame.Invoke(currentLevel);
        Invoke("StartGame", 1.5f);
    }
    public void StartGame()
    {
        if (OnStartGame != null)
            OnStartGame();
    }
    public void PauseGame()
    {
        if (OnPauseGame != null)
            OnPauseGame();
    }
    public void WinGame()
    {
        if (OnWinGame != null)
            OnWinGame();
        NextGame();
    }
    public void LoseGame()
    {
        if (OnLoseGame != null)
            OnLoseGame();
        Invoke("StartGame", 1.5f);
    }
    public void NextGame()
    {
        InitGame(CurrentLevel++);
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
