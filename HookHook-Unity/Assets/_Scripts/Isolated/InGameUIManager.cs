using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public Button Pause, Home;
    public GameObject WinView, LoseView, ProgressView, PauseView;
    public Image AnchorProgress;
    public float leftProgress, rightProgress;
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
        AnchorProgress.rectTransform.position = new Vector3(leftProgress, AnchorProgress.rectTransform.position.y, AnchorProgress.rectTransform.position.z);
        Debug.Log(AnchorProgress.rectTransform.position);
    }
    public void OnUpdateProgress(float percentage)
    {
        if (percentage < 0) percentage = 0;
        float desiredProgress = percentage * (rightProgress - leftProgress) - leftProgress * 2;
        AnchorProgress.rectTransform.position = new Vector3(desiredProgress, AnchorProgress.rectTransform.position.y, AnchorProgress.rectTransform.position.z);
        Debug.Log(AnchorProgress.rectTransform.position);
    }
    public void PopUpWin()
    {
        StartCoroutine(WinGame());
    }
    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(2);
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
}
