using UnityEngine;

public class RockObstacle : AbstractObstacle
{
    private void Start() 
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        Debug.Log("fire start");    
    }
    public override void Affect(GameObject go)
    {
        throw new System.NotImplementedException();
    }

    public override void RunAnimation()
    {
        throw new System.NotImplementedException();
    }
}