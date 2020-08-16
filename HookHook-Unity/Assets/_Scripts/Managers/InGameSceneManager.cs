using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    public GameObject[] LevelPrefabList;

    private void Start() 
    {
        RenderLevel(0);    
    }
    public void RenderLevel(int id)
    {
        GameObject level = Instantiate(LevelPrefabList[id],Vector3.zero,Quaternion.identity);
    }
}