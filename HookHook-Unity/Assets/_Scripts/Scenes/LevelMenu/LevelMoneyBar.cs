using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PUser;
using TMPro;

public class LevelMoneyBar : MonoBehaviour
{
    public TextMeshProUGUI MoneyText;
    int currentMoney;

    void OnEnable()
    {
        currentMoney = GetMoneyFromUser();
    }

    void Update()
    {
        MoneyText.text = currentMoney.ToString();    
    }
    int GetMoneyFromUser()
    {
        int userMoney = UserRepository.User.Money;
        return userMoney;
    }
}
