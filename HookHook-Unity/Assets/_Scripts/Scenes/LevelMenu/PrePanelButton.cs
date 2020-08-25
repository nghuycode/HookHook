using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePanelButton : MonoBehaviour
{
    public void OnClick()
    {
        LevelManager.LM.GoToPrePanel();
    }
}
