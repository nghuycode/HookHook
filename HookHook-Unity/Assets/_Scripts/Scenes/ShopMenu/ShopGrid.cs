using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGrid : MonoBehaviour
{
    public int gridID;
    public int price;
    public bool isUnlock;

    public ShopGrid(int _gridID, bool _isUnlock)
    {
        gridID = _gridID;
        isUnlock = _isUnlock;
    }


    public void OnClick()
    {
        Debug.Log(gridID);
    }

    public void UnlockItem()
    {
    }
}
