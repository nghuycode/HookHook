using PItem;
using PShop;
using System.Collections.Generic;
using UnityEngine;

public class AddItemShop : MonoBehaviour
{
    public List<Item> items;
    private void Awake()
    {
        Shop shop = new Shop { Items = items };
        ShopRepository.Shop = shop;
    }
}
