using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotateY(gameObject, transform.rotation.y + 90,2).setEaseInOutExpo(); //.moveY(gameObject, transform.position.y+6, 2).setEaseInOutExpo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
