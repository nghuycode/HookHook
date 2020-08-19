using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller<GameplayApp>
{
    private void Start()
    {
        InputHandler.Instance.OnTouchScreen += ShootRope;
        InputHandler.Instance.OnReleaseScreen += ReleaseRope;
        GameManager.Instance.OnStartGame += ActivePlayer;
        GameManager.Instance.OnWinGame += DeactivePlayer;
        GameManager.Instance.OnLoseGame += DeactivePlayer;
    }
    public void ActivePlayer()
    {
        Debug.Log("active");
        app.model.PlayerModel.CanPlay = true;

        this.transform.position = app.model.PlayerModel.DefaultPosition;
        app.view.PlayerView.sprite.enabled = true;
        app.view.PlayerView.trail.enabled = true;
        app.view.PlayerView.rope.enabled = true;
        app.view.PlayerView.rb.gravityScale = 1;
    }
    public void DeactivePlayer()
    {
        Debug.Log("deactive");
        app.model.PlayerModel.CanPlay = false;

        this.transform.position = app.model.PlayerModel.DefaultPosition;
        app.view.PlayerView.sprite.enabled = false;
        app.view.PlayerView.trail.enabled = false;
        app.view.PlayerView.rope.enabled = false;
        app.view.PlayerView.rb.gravityScale = 0;
        app.view.PlayerView.rb.velocity = Vector2.zero;
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
