using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRun : MonoBehaviour
{
    private float speed = 4f;
    private float maxZ = 4f;

    private void Start()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (transform.position.z < maxZ)
        {
            Vector3 newPos = transform.position;
            newPos.z += speed * Time.deltaTime;

            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }

    }
}
