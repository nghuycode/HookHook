using PItem;
using PModels;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Item item in DataRepository.Shop.Items)
        {
            Debug.Log(item.Id + " " + item.Name + " " + item.Price);
        }
        Debug.Log(DataRepository.User.Name);
        Debug.Log(DataRepository.User.Money);
        foreach (Item item in DataRepository.User.Purchased)
        {
            Debug.Log(item.Id + " " + item.Name + " " + item.Price);
        }
    }
}
