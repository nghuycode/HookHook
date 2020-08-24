using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float speed;
    private void Awake() {
        Invoke("StartFaded", 3);
    }
    public void StartFaded() {
        StartCoroutine(FadeOut(Text));
    }
    IEnumerator FadeOut(TextMeshProUGUI IMG)
    {
        for (float f = 1; f > 0; f -= 0.05f)
        {
            Color c = IMG.color;
            c.a = f;
            IMG.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        IMG.enabled = false;
    }
}
