using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : Entity
{

    public virtual void OnAnimationEnd() { }
}

public class View<T> : View where T : App
{
    new public T app
    {
        get
        {
            return (T)base.app;
        }
    }
}
