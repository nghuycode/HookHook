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
        if (this.transform.childCount > 0)
        GameObject.Destroy(this.transform.GetChild(0).gameObject);
        //Instantiate level
        if (id < LevelPrefabList.Length)
        {
            GameObject level = Instantiate(LevelPrefabList[id],Vector3.zero,Quaternion.identity);
            level.transform.SetParent(this.transform);
        }
        else {
            GameObject level = Instantiate(LevelPrefabList[LevelPrefabList.Length - 1],Vector3.zero,Quaternion.identity);
            level.transform.SetParent(this.transform);
        }
    }
}