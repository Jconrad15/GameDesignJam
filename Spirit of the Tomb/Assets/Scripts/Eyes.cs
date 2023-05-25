using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField]
    private GameObject[] eyes;

    private void Start()
    {
        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].SetActive(false);
        }

        StartCoroutine(ShowEyes());
    }

    private IEnumerator ShowEyes()
    {
        yield return new WaitForSeconds(8f);

        for (int i = 0; i < eyes.Length; i++)
        {
            eyes[i].SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }

}
