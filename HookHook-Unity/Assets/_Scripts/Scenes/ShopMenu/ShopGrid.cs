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
    public GameObject notBought, isBought, isSelect,notPublic;
    public Image shopImg;
    public Text priceText;
    public ShopPanelManager baseManager;
    public void Instance(Item _item)
    {
        item = _item;
        curState = state.isLocked;
        notPublic.SetActive(false);
        notBought.SetActive(true);
        this.GetComponent<Button>().enabled = true;
        shopImg.sprite = ModelManager.MM.GetModel(item.Id).sprite;

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

            Debug.Log(baseManager.GetGridIndex(60));
            Debug.Log(baseManager.GetGridIndex(61));

            baseManager.shopGrid[baseManager.GetGridIndex(UserRepository.Select(item).Id)].DeSelectItem(); //Get
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
        isBought.SetActive(true);
        notBought.SetActive(false);
        //Change Img
    }

    public void SelectItem()
    {
        curState = state.isSelect;
        isSelect.SetActive(true);
        isBought.SetActive(false);
        SetButtonOpacity(this.GetComponent<Button>(), 0.5f);
        this.gameObject.GetComponent<Button>().enabled = false;
        ShopPanelUser.SPU.UpdateImg(ModelManager.MM.GetModel(item.Id));
    }

    public void DeSelectItem()
    {
        curState = state.isUnselect;
        isSelect.SetActive(false);
        isBought.SetActive(true);
        this.gameObject.GetComponent<Button>().enabled = true;
        SetButtonOpacity(this.GetComponent<Button>(), 1f);
    }

    void SetButtonOpacity(Button button, float opacity)
    {
        Color temp = button.image.color;
        temp.a = opacity;
        button.image.color = temp;
    }
}

