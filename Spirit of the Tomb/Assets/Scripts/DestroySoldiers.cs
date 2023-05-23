using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoldiers : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
