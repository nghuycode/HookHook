using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject[] Effects;
    private void Start() {
        GameManager.Instance.OnStartGame += GenerateEffects;
    }
    private void GenerateEffects() {
        int numberOfEffect = Random.Range(1, 3);
        int effectIndex = -1, tmp = -1;
        for (int i = 0; i < numberOfEffect; ++i) {
            do 
            {
                tmp = Random.Range(0, Effects.Length);
            }
            while (tmp == effectIndex);
            effectIndex = tmp;
            Effects[effectIndex].SetActive(true);
        }
    }
}
