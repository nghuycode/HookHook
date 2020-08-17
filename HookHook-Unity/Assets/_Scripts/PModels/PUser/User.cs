using PHelper;
using PItem;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace PUser
{
    public class User
    {
        public string Name = "";
        public int Money = 0;
        public List<Item> Purchased = new List<Item>();
        public int Level = 0;
        public List<Item> Equipped = new List<Item>();

        public User()
        {
            string data = SaveLoadHelper.Load("/user");
            if (data != null)
            {
                UserSaveModel tmp = JsonUtility.FromJson<UserSaveModel>(data);
                this.Name = tmp.Name;
                this.Money = tmp.Money;
                this.Purchased = tmp.Purchased;
                this.Level = tmp.Level;
                this.Equipped = tmp.Equipped;
            }
            else
                Save();
        }

        public void NewUser(string name)
        {
            this.Name = name;
            Save();
        }

        private void Save()
        {
            SaveLoadHelper.Save("/user", this);
        }

        public void addItem(Item item)
        {
            Purchased.Add(item);
            Save();
        }


    }
}