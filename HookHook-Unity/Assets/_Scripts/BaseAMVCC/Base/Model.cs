using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : Entity
{
}

public class Model<T> : Model where T : App
{
    new public T app
    {
        get
        {
            return (T)base.app;
        }
    }
}
