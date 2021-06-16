using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations; 

public class AddressableManager : MonoBehaviour
{
    public Text LogText;
    public AssetReference HookHookScene;
    public void LoadHookHookSceneAsync() 
    {
        //HookHookScene.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
        StartCoroutine(DownloadScene());
    }
    private IEnumerator DownloadScene() 
    {
        var downloadScene = Addressables.LoadSceneAsync(HookHookScene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        downloadScene.Completed += SceneDownloadComplete;
        LogText.text = "Start downloading scene";

        while (!downloadScene.IsDone)
        {
            var status = downloadScene.GetDownloadStatus();
            float progress = status.Percent;
            LogText.text += "\n" +  "Downloading:" + status.DownloadedBytes;
            Debug.Log("Downloading:" + progress);
            yield return null;
        }
        LogText.text += "\n" +  "Downloaded scene";
        Debug.Log("Downloaded scene");
    }
    private void SceneDownloadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> _handle) 
    {
        if (_handle.Status == AsyncOperationStatus.Succeeded)
        {
            LogText.text += "\n" +  "Completed";
            Debug.Log("Completed");
        }
        else if (_handle.Status == AsyncOperationStatus.Failed)
        {
            LogText.text += "\n" +  _handle.OperationException;
            Debug.Log("Failed");
        }
    }



    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
