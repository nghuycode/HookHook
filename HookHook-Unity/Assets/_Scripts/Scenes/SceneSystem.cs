using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public GameObject StartMenu, ShopMenu, LevelMenu, SettingsMenu,LoadingScene;
  
    public static SceneSystem SM;

    void Awake()
    {
        if (SM != null)
            GameObject.Destroy(SM);
        else
            SM = this;
    }
    public void StartMenuToSettingsMenu()
    {
        ActivateScene(SettingsMenu);
        DeactivateScene(StartMenu);
    }

    public void SettingsMenuToStartMenu()
    {
        ActivateScene(StartMenu);
        DeactivateScene(SettingsMenu);
    }

    public void StartMenuToShopMenu()
    {
        ActivateScene(ShopMenu);
        DeactivateScene(StartMenu);
    }

    public void ShopMenuToStartMenu()
    {
        ActivateScene(StartMenu);
        DeactivateScene(ShopMenu);
    }

    public void StartMenuToLevelMenu()
    {
        ActivateScene(LevelMenu);
        DeactivateScene(StartMenu);
    }

    public void LevelMenuToStartMenu()
    {
        ActivateScene(StartMenu);
        DeactivateScene(LevelMenu);
    }

    public void LevelMenuToGameMenu()
    {
        DeactivateScene(LevelMenu);
        ActivateScene(LoadingScene);
        Invoke("LoadGame", 2f);
    }

   
    public void GameMenuToLevelMenu()
    {
        SceneManager.LoadScene("Menu");
        StartMenu = GameObject.Find("StartMenu");
        ShopMenu = GameObject.Find("ShopMenu");
        LevelMenu = GameObject.Find("LevelMenu");
        SettingsMenu = GameObject.Find("SettingMenu");
    }

    void SetAllChild(GameObject targetObject, bool activeState)
    {
        targetObject.SetActive(activeState);
        for (int i = 0; i < targetObject.transform.childCount; i++)
            SetAllChild(targetObject.transform.GetChild(i).gameObject, activeState);
    }
    
    void ActivateScene(GameObject targetScene)
    {
        targetScene.SetActive(true);
        SetAllChild(targetScene.GetComponent<SceneComponent>().control, true);
        
    }

    void DeactivateScene(GameObject targetScene)
    {
       
        targetScene.SetActive(false);
        SetAllChild(targetScene.GetComponent<SceneComponent>().control, false);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("DemoHook");
    }
}
