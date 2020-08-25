using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanelButton : MonoBehaviour
{
    public void OnClick()
    {
        LevelManager.LM.GoToNextPanel();
    }
}
