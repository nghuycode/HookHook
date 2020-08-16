﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller<GameplayApp>
{
    private void Start()
    {
        InputHandler.Instance.OnTouchScreen += ShootRope;
        InputHandler.Instance.OnReleaseScreen += ReleaseRope;
    }
    public void ShootRope()
    {
        if (app.model.PlayerModel.CanPlay)
        {
            if (!app.model.PlayerModel.IsSwinging)
            {
                app.view.PlayerView.OnShootRope();
                app.model.PlayerModel.IsSwinging = true;
            }
            else
            {
                app.view.PlayerView.OnSwingRope();
            }
        }
    }
    public void ReleaseRope()
    {
        if (app.model.PlayerModel.CanPlay)
        {
            app.view.PlayerView.OnReleaseRope();
            app.model.PlayerModel.IsSwinging = false;
        }
    }
    public void PlayerWin()
    {
        app.model.PlayerModel.CanPlay = false;
        GameManager.Instance.WinGame();
        Debug.Log("Win");
    }
    public void PlayerLose()
    {
        app.model.PlayerModel.CanPlay = false;
        GameManager.Instance.LoseGame();
        Debug.Log("Lose");
    }
    public void UpdateProgressMap(float percentage)
    {
        GameManager.Instance.UpdateProgressLevel(percentage);
    }
}
