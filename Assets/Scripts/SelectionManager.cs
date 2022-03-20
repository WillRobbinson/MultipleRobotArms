using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance = null;
    // props
    public GameObject selectedObject = null;
    public float wheelValueG = -9999;

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
    private void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");
        if (wheelValue != wheelValueG)
        {
            wheelValueG = wheelValue;
            if (wheelValue > 0f) // forward
            {
                print("Forward: " + wheelValue);
            }
            else
            {
                print("Backward: " + wheelValue);
            }
        }
    }

}
