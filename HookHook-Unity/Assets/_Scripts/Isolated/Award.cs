using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]
    private Vector3 defaultPosition;
    private void Start()
    {
        Player = GameObject.Find("Player");
        defaultPosition = this.transform.position;

        GameManager.Instance.OnStartGame += OnStartGame;
        GameManager.Instance.OnWinGame += OnWinGame;
    }
    public void OnStartGame()
    {
        this.transform.SetParent(null);
        this.transform.position = defaultPosition;
    }
    public void OnWinGame()
    {
        this.transform.SetParent(Player.transform);
        this.transform.localPosition = new Vector3(-.4f, 1.6f, 0);
    }
}
