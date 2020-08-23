using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovable : MonoBehaviour
{
    public float range;
    public float speed;
    float startScale, curScale,preScale;
    void Start()
    {
        startScale = this.transform.localScale.x;
        curScale = startScale;
    }
    void Update()
    {
        curScale = this.transform.localScale.x;
        preScale = curScale;
        if (speed > 0)
        {
            if (curScale + speed > startScale + range)
            {
                curScale = startScale + range;
                speed = -speed;
            }
            else curScale = curScale + speed;
        }
        else
        {
            if (curScale + speed < startScale - range)
            {
                curScale = startScale - range;
                speed = -speed;
            }
            else curScale = curScale + speed;
        }

    }
}
