using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PUser;
using UnityEngine.UI;
using TMPro;

public class ShopMoneyBar : MonoBehaviour
{
    
    int currentMoney;
    public TextMeshProUGUI MoneyText;
    void Update()
    {
        currentMoney = GetMoneyFromUser();
        MoneyText.text = currentMoney.ToString();    
    }
    int GetMoneyFromUser()
    {
        int userMoney = 0;
        userMoney = UserRepository.User.Money;
        return userMoney;
    }
}
