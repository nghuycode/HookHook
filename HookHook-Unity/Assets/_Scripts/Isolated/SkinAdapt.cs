using PUser;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAdapt : MonoBehaviour
{
    public GameObject Player, Rope, Background;
    public Sprite[] PlayerSkinSprites;
    public RuntimeAnimatorController[] PlayerSkinAnimators;

    public Color32[] Colors;
    void Start()
    {
        GameManager.Instance.OnStartGame += AdaptSkin;
    }

    public void AdaptSkin()
    {
        //Player
        AdaptPlayer();
        //Rope
        AdaptRope();
        //Background
        AdaptBackground();
    }
    private void AdaptPlayer()
    {
        int ID = UserRepository.User.currentSkin.Id;
        Player.GetComponent<SpriteRenderer>().sprite = PlayerSkinSprites[ID];
        Player.GetComponent<Animator>().runtimeAnimatorController = PlayerSkinAnimators[ID];
    }
    private void AdaptRope()
    {
        int ID = UserRepository.User.currentRope.Id % 30;
        Rope.GetComponent<LineRenderer>().startColor = Color.white;
        Rope.GetComponent<LineRenderer>().endColor = Colors[ID];
    }
    private void AdaptBackground()
    {

    }

}
