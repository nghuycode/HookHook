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
            Debug.Log("Shoot Rope");
            app.view.PlayerView.OnShootRope();
            app.model.PlayerModel.IsSwinging = true;
        }
        else
        {
            Debug.Log("Swing Rope");
            app.view.PlayerView.OnSwingRope();
        }
    }
    public void ReleaseRope()
    {
        Debug.Log("Release Rope");
        app.view.PlayerView.OnReleaseRope();
        app.model.PlayerModel.IsSwinging = false;
    }
}
