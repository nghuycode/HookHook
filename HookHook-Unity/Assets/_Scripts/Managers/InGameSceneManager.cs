using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameObject[] LevelPrefabList;

    [SerializeField]
    private Vector3 playerDefaultPosition;
    private GameObject Player;

    private void Awake() 
    {
        Player = GameObject.Find("Player");
        RenderLevel(0);    
    }
    public void RenderLevel(int id)
    {
        //Instantiate level
        GameObject level = Instantiate(LevelPrefabList[id],Vector3.zero,Quaternion.identity);
        level.transform.SetParent(this.transform);

        //Show player and Reset Player position
        Player.GetComponent<SpriteRenderer>().enabled = true;
        Player.transform.position = playerDefaultPosition;
    }
}