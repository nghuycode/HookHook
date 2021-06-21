using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations; 

public class AddressableSceneManager : MonoBehaviour
{   
    public static AddressableSceneManager Instance;
    [Serializable]
    public struct GameScene 
    {
        public string NameScene;
        public AssetReference RealScene;
    }
    public GameScene[] GameScenes;

    public void LoadGameSceneAsync(string nameScene) 
    {
        StartCoroutine(DownloadScene(getSceneByName(nameScene)));
    }
    private AssetReference getSceneByName(string nameScene) 
    {
        for (int i = 0; i < GameScenes.Length; ++i)
            if (GameScenes[i].NameScene == nameScene)
                return GameScenes[i].RealScene;
        Debug.LogWarning("We can't find that scene !!!");
        return null;
    }
    private IEnumerator DownloadScene(AssetReference scene) 
    {
        var downloadScene = Addressables.LoadSceneAsync(scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
        downloadScene.Completed += SceneDownloadComplete;
        while (!downloadScene.IsDone)
        {
            var status = downloadScene.GetDownloadStatus();
            float progress = (int)(status.Percent * 100);
            Debug.Log("Downloading:" + progress);
            yield return null;
        }
        Debug.Log("Downloading:" + downloadScene.GetDownloadStatus().Percent * 100);
        Debug.Log("Downloaded scene");
    }
    private void SceneDownloadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> _handle) 
    {
        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Completed");
        }
        else if (_handle.Status == AsyncOperationStatus.Failed)
        {
            Debug.Log("Failed");
        }
    }




    #region MONO BEHAVIOUR METHODS
    private void Awake() 
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    #if UNITY_EDITOR
        Addressables.ClearResourceLocators();
    #endif
    }
    #endregion
}
