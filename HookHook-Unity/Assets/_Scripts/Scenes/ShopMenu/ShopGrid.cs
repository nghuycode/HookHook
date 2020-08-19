using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PItem;
using PUser;


public class ShopGrid : MonoBehaviour
{
    public int gridID;
    public enum state { isLocked,isSelect,isUnselect};
    public state curState;
    public Item item;
    public GameObject notBought, isBought, isSelect;
    public Image shopImg;
    public Text priceText;
    public ShopPanelManager baseManager;
    public void Instance(Item _item)
    {
        
        item = _item;
        curState = state.isLocked;
        //attach Img
        priceText.text = item.Price.ToString();    
    }
    public void OnClick()
    {
        if(curState == state.isLocked)
        {
            BuyItem();
        }
        else if(curState == state.isUnselect)
        {
            baseManager.shopGrid[UserRepository.Select(item).Id].DeSelectItem(); //Get
            SelectItem();
        }
    }

    void BuyItem()
    {
        if(UserRepository.Buy(item))
        {
            UnlockItem();
        }
    }


    public void UnlockItem()
    {
        curState = state.isUnselect;
        priceText.text = "USE".ToString();
        isBought.SetActive(true);
        notBought.SetActive(false);
        //Change Img
    }

    public void SelectItem()
    {
        curState = state.isSelect;
        isSelect.SetActive(true);
        isBought.SetActive(false);
        priceText.text = "IsSelect".ToString();
        this.gameObject.GetComponent<Button>().enabled = false;
    }

    public void DeSelectItem()
    {
        curState = state.isUnselect;
        isSelect.SetActive(false);
        isBought.SetActive(true);
        priceText.text = "Choose".ToString();
        this.gameObject.GetComponent<Button>().enabled = true;
    }
}
