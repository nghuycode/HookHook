using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    public Button Pause, Home;
    public GameObject WinView, LoseView, PauseView, CoinView;
    public TextMeshProUGUI Level, Coin, UserCoinWin, Intro;
    public GameplayApp app;
    private void Start()
    {
        GameManager.Instance.OnInitGame += OnInitGame;
        GameManager.Instance.OnWinGame += PopUpWin;
        GameManager.Instance.OnLoseGame += PopUpLose;
        GameManager.Instance.OnUpdateCoin += OnUpdateCoin;
    }
    public void OnInitGame(int currentLevel)
    {
        WinView.SetActive(false);
        LoseView.SetActive(false);
        PauseView.SetActive(false);
        Home.gameObject.SetActive(false);   
        Pause.gameObject.SetActive(true);
        Level.gameObject.SetActive(true);
        Level.text = "LEVEL\n" + (currentLevel + 1);
        if (currentLevel == 0)
            Intro.gameObject.SetActive(true);
        CoinView.SetActive(true);
        Coin.text = "x0";
    }
    public void PopUpWin()
    {
        StartCoroutine(WinGame());
    }
    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1);
        WinView.SetActive(true);
        UserCoinWin.text = "X" + app.model.PlayerModel.Money;
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
    }
    public void PopUpLose()
    { 
        LoseView.SetActive(true);
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        AudioManager.AM.Play("Button");
        Home.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        PauseView.SetActive(true);
        GameManager.Instance.PauseGame();
    }
    public void ResumeGame()
    {
        AudioManager.AM.Play("Button");
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
        AudioManager.AM.Play("Button");
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void OnUpdateCoin(int coinCount) {
        Coin.text = "X" + coinCount.ToString();
    }
}
