using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelBackButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneSystem.SM.LevelMenuToStartMenu();
    }
}
