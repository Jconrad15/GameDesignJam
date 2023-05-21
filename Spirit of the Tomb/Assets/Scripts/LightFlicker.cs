using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light l;

    private void Start()
    {
        l = GetComponent<Light>();
    }

    private void Update()
    {
        if (Random.value > 0.5f)
        {
            l.intensity = Random.Range(0.5f, 1.5f);
        }
    }
}
