using System.Collections;
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
    public void ReleaseRope()
    {
        app.view.PlayerView.OnReleaseRope();
        app.model.PlayerModel.IsSwinging = false;
    }
}
