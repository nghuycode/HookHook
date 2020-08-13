using UnityEngine;

public abstract class AbstractObstacle : MonoBehaviour
{
    public abstract void RunAnimation();
    public abstract void Affect(GameObject go);
}
