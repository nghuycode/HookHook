using PUser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAdapt : MonoBehaviour
{
    public GameObject Player, Rope, Background;
    void Start()
    {
        GameManager.Instance.OnInitGame += AdaptSkin;
    }

    public void AdaptSkin(int currentLevel)
    {
        //Player

        //Rope

        //Background
    }

}
