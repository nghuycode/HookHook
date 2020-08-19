using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PShop;
using PUser;
using PModels;


public class ShopBgManager : ShopPanelManager
{
    void Awake()
    {
        isSelect = false;
        ToTalItems = DataRepository.Shop.Items.Count;
        gridObject = new List<GameObject>(ToTalItems);
        shopGrid = new List<ShopGrid>(ToTalItems);
        for (int i = 0; i < ToTalItems; i++)
        {
            InstantiateIn(ref gridObject, i, Panel);
            shopGrid.Add(gridObject[i].GetComponent<ShopGrid>());
            SetGridInfo(i);
        }
    }

    void OnEnable()
    {
        GridsInstantiate();
    }
}
