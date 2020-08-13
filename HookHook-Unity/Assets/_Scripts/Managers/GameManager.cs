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
    #endregion
    #region Events and Actions
    public event Action OnInitGame;
    public event Action OnStartGame;
    public event Action OnPauseGame;
    public event Action OnWinGame;
    public event Action OnLoseGame;

    public event Action OnUpdateProgressLevel;
    public event Action OnUpdateGem;
    public void InitGame()
    {
        if (OnInitGame != null)
            OnInitGame();
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
    }
    public void LoseGame()
    {
        if (OnLoseGame != null)
            OnLoseGame();
    }
    public void UpdateProgressLevel()
    {
        if (OnUpdateProgressLevel != null)
            OnUpdateProgressLevel();
    }
    public void UpdateGem()
    {
        if (OnUpdateGem != null)
            OnUpdateGem();
    }
    #endregion
}
