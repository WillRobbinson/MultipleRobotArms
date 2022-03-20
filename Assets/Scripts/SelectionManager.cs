using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance = null;
    // props
    public GameObject selectedObject = null;
    public Material previouslySelectedObjectMaterial = null;

    void Awake()
    {
        print("Awake in SelectionManager");
        if (instance == null)
        {
            print("Awake instance was null, assigning.");
            instance = this;
        } else if (instance != this)
        {
            print("Awake Destroy");
            Destroy(gameObject);
        }
    }

}
