using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations; 

public class AddressableManager : MonoBehaviour
{
    public AssetReference HookHookScene;
    public void LoadHookHookSceneAsync() 
    {
        HookHookScene.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
