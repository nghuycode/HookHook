﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.SM.StartMenuToLevelMenu();
    }
}