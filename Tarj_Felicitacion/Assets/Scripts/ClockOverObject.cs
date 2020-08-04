using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOverObject : MonoBehaviour
{

    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;


    private void OnMouseDown()
    {
        StartCoroutine(ActivateAtEndOfFrame());
    }

    private IEnumerator ActivateAtEndOfFrame()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }

        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }

    }

}
