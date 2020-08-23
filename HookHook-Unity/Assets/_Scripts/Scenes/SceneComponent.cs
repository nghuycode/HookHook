using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneComponent : MonoBehaviour
{
    public GameObject control;
    public Animator StartScene;


    public void SetOn()
    {
        StartScene.SetBool("On", true);
        Invoke("SetOnToOff", 0.1f);

    }

    void SetOnToOff()
    {
        StartScene.SetBool("On", false);
    }
    public void SetOff()
    {
        StartScene.SetBool("Off", true);
        Invoke("SetOffToOff", 0.1f);
    }

    void SetOffToOff()
    {
        StartScene.SetBool("Off", false);
    }
}
