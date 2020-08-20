using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour
{
    static public ModelManager MM;
    public ModelElement baseElement;
    public ModelElement[] modelElements;
    void Awake()
    {
        if (MM != null)
            GameObject.Destroy(MM);
        else
            MM = this;
     //   DontDestroyOnLoad(this);
    }

    public Image GetModel(int id)
    {
        for (int i = 0;i < modelElements.Length;i++)
            if(id == modelElements[i].id)
            return modelElements[i].img;
        
        return baseElement.img;
    }
}
