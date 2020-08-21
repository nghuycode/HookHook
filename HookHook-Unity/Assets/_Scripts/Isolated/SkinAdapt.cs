using PUser;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SkinAdapt : MonoBehaviour
{
    public GameObject Player, Rope, Background;
    public Sprite[] PlayerSkinSprites;
    public AnimatorController[] PlayerSkinAnimators;
    void Start()
    {
        GameManager.Instance.OnInitGame += AdaptSkin;
    }

    public void AdaptSkin(int currentLevel)
    {
        //Player
        AdaptPlayer();
        //Rope
        AdaptRope();
        //Background
    }
    private void AdaptPlayer()
    {
        int ID = UserRepository.User.currentSkin.Id;
        Player.GetComponent<SpriteRenderer>().sprite = PlayerSkinSprites[ID];
        Player.GetComponent<Animator>().runtimeAnimatorController = PlayerSkinAnimators[ID];
    }
    private void AdaptRope()
    {
        
    }
    private void AdaptBackground()
    {

    }

}
