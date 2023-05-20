using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private float openDoorTime;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerDoor");

        if (other.gameObject.CompareTag("MainCamera"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        float timer = 0;
        while(timer < openDoorTime)
        {
            MoveDoor();
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
        Destroy(gameObject);
    }

    private void MoveDoor()
    {
        Vector3 newPos = door.transform.position;
        newPos.y += 0.01f;
        door.transform.position = newPos;
    }
}
