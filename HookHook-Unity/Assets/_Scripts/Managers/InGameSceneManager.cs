using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameObject[] LevelPrefabList;

    private void Start() 
    {
        GameManager.Instance.OnInitGame += RenderLevel;
    }
    public void RenderLevel(int id)
    {
        //Instantiate level
        GameObject level = Instantiate(LevelPrefabList[id],Vector3.zero,Quaternion.identity);
        level.transform.SetParent(this.transform);
    }
}