using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public GameObject StartMenu, ShopMenu, LevelMenu, SettingsMenu,LoadingScene;
    public GameObject BlockCanvas;
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
        StartCoroutine(ChangeScene(StartMenu, SettingsMenu));
    }

    public void SettingsMenuToStartMenu()
    {
        StartCoroutine(ChangeScene(SettingsMenu, StartMenu));
    }

    public void StartMenuToShopMenu()
    {
        StartCoroutine(ChangeScene(StartMenu, ShopMenu));
    }

    public void ShopMenuToStartMenu()
    {
        StartCoroutine(ChangeScene(ShopMenu, StartMenu));
    }

    public void StartMenuToLevelMenu()
    {
        StartCoroutine(ChangeScene(StartMenu, LevelMenu));
    }

    public void LevelMenuToStartMenu()
    {
        StartCoroutine(ChangeScene(LevelMenu, StartMenu));
    }

    public void LevelMenuToGameMenu()
    {
        StartCoroutine(LoadGame(LevelMenu));        
        
    }


    void SetAllChild(GameObject targetObject, bool activeState)
    {
        targetObject.SetActive(activeState);
        for (int i = 0; i < targetObject.transform.childCount; i++)
            SetAllChild(targetObject.transform.GetChild(i).gameObject, activeState);
    }
    
    IEnumerator ChangeScene(GameObject sceneA, GameObject sceneB)
    {
        sceneA.GetComponent<SceneComponent>().SetOff();
        BlockCanvas.SetActive(true);
        yield return new WaitForSeconds(.3f);
        DeactivateScene(sceneA);
        ActivateScene(sceneB);
        sceneB.GetComponent<SceneComponent>().SetOn();
        BlockCanvas.SetActive(false);
        yield return null;
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



    IEnumerator LoadGame(GameObject LevelMenu)
    {
        DeactivateScene(LevelMenu);
        ActivateScene(LoadingScene);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("DemoHook");
        
    }
}
