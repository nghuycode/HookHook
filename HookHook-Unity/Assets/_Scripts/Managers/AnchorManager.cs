using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
    public static AnchorManager Instance;

    private int currentAnchorID = 0;
    [SerializeField]
    private List<Anchor> listAnchor;
    [SerializeField]
    private GameObject anchorPool, player;


    #region Mono Behaviour
    private void Awake()
    {
        Instance = this;
        initListAnchor();
    }
    #endregion
    #region Anchor Manager Behavior
    private void initListAnchor()
    {
        for (int i = 0; i < anchorPool.transform.childCount; ++i)
            listAnchor.Add(anchorPool.transform.GetChild(i).GetComponent<Anchor>());
    }
    private void addAnAnchor(Anchor anchor)
    {
        listAnchor.Add(anchor);
    }
    public Anchor FindNearestAnchorWithPlayer(Vector3 playerPosition, bool isSwinging)
    {
        if (!isSwinging)
        {
            float minDistance = 1000;
            int minDistanceAnchorID = 0;
            for (int i = 0; i < listAnchor.Count; ++i)
            {
                //Optimize
                //Implement optimize here...
                Debug.Log(i + ":" + distance(playerPosition, listAnchor[i].transform.position));
                if (minDistance > distance(playerPosition, listAnchor[i].transform.position))
                {
                    minDistance = distance(playerPosition, listAnchor[i].transform.position);
                    minDistanceAnchorID = i;
                }
            }
            currentAnchorID = minDistanceAnchorID;
            return listAnchor[minDistanceAnchorID];
        }
        else
            return listAnchor[currentAnchorID];
    }
    #endregion
    #region Others
    float distance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }

    #endregion  
}
