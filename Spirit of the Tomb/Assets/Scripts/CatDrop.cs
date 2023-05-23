using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDrop : MonoBehaviour
{
    private float speed = 0.5f;
    private float minY = 1.5f;

    private void Start()
    {
        StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        yield return new WaitForSeconds(1f);

        while (transform.position.y > minY)
        {
            Vector3 newPos = transform.position;
            newPos.y -= speed * Time.deltaTime;

            transform.position = newPos;
            yield return new WaitForEndOfFrame();
        }

    }


}
