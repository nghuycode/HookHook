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

        GameManager.Instance.OnInitGame += OnInitGame;
        GameManager.Instance.OnWinGame += OnWinGame;
    }
    public void OnInitGame(int currentLevel)
    {
        this.transform.SetParent(null);
        this.transform.position = defaultPosition;
        this.transform.eulerAngles = Vector3.zero;
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void OnWinGame()
    {
        GameManager.Instance.OnInitGame -= OnInitGame;
        GameManager.Instance.OnWinGame -= OnWinGame;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.transform.SetParent(Player.transform);
        this.transform.localPosition = new Vector3(-.4f, 1.6f, 0);
        StartCoroutine(DestroyAward());
    }
    IEnumerator DestroyAward()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(this.gameObject);
    }
}
