using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpToPosition : MonoBehaviour
{
    public Vector3 positionToMoveTo;
    public int newYValue = 2;
    void Start()
    {
        positionToMoveTo = new Vector3(transform.position.x, newYValue, transform.position.z);
        StartCoroutine(LerpPosition(positionToMoveTo, 1));
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}