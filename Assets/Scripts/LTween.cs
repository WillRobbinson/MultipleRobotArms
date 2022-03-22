using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example5Coroutine());
        StartCoroutine(Example10Coroutine());
        StartCoroutine(Example15Coroutine());
    }

    IEnumerator Example5Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        print("5 secs");
        LeanTween.rotateY(gameObject, transform.rotation.y + 90, 1).setEaseInOutExpo();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator Example10Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
        print("10 secs");
        LeanTween.rotateY(gameObject, transform.rotation.y + 180, 1).setEaseInOutExpo();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator Example15Coroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);
        print("15 secs");
        LeanTween.rotateY(gameObject, transform.rotation.y + 270, 1).setEaseInOutExpo();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    //    LeanTween.rotateY(gameObject, transform.rotation.y + 90, 2).setEaseInOutExpo(); //.moveY(gameObject, transform.position.y+6, 2).setEaseInOutExpo();
    //}
}
