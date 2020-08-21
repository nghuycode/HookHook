using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public Button Pause, Home;
    public GameObject WinView, LoseView, ProgressView, PauseView;
    public Slider AnchorProgress;
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
        AnchorProgress.value = 0;
    }
    public void OnUpdateProgress(float percentage)
    {
        if (percentage < 0) percentage = 0;
        AnchorProgress.value = percentage;
    }
    public void PopUpWin()
    {
        StartCoroutine(WinGame());
    }
    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1);
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
    public void NextGame()
    {
        GameManager.Instance.NextGame();
    }
    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }
    public void BackToHome()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
