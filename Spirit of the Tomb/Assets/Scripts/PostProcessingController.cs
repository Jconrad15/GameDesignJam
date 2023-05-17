using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    private ChromaticAberration ca;

    private float timer = 0;
    private float caFadeSpeed = 0.1f;
    private float caEditThreshold = 5f;

    private void Start()
    {
        volume.profile.TryGet(out ca);
    }

    private void Update()
    {
        if (timer > caEditThreshold)
        {
            EditChromaticAberration();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void EditChromaticAberration()
    {
        ca.intensity.value = 1;
        StartCoroutine(ChromaticAberrationFade());
    }

    private IEnumerator ChromaticAberrationFade()
    {
        while (ca.intensity.value > 0)
        {
            float newIntensity = Mathf.Clamp01(
                ca.intensity.value - (Time.deltaTime * caFadeSpeed));
            ca.intensity.value = newIntensity;

            yield return new WaitForEndOfFrame();
        }

        ca.intensity.value = 0;
    }


}