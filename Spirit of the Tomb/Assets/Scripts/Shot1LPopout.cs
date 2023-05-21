using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot1LPopout : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    private float maxZ = 1.5f;
    private float minZ = 1.0f;
    private float speed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            StartCoroutine(Popout());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            StartCoroutine(Hide());
        }
    }

    private IEnumerator Popout()
    {
        Vector3 endPos = character.transform.position;
        endPos.z = minZ;

        while (character.transform.position.z > minZ)
        {
            Vector3 newPos = character.transform.position;
            newPos.z -= speed * Time.deltaTime;
            character.transform.position = newPos;

            yield return new WaitForEndOfFrame();
        }

        character.transform.position = endPos;
    }

    private IEnumerator Hide()
    {
        Vector3 endPos = character.transform.position;
        endPos.z = maxZ;

        while (character.transform.position.z < maxZ)
        {
            Vector3 newPos = character.transform.position;
            newPos.z += 2f * speed * Time.deltaTime;
            character.transform.position = newPos;

            yield return new WaitForEndOfFrame();
        }

        character.transform.position = endPos;
        Destroy(character);
    }

}
