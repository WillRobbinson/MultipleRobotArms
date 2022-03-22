using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance = null;
    // props
    public GameObject selectedObject = null;
    public float wheelValueG = -9999;
    public JointRotator jointRotator;

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
        if (selectedObject == null) return;

        float wheelValue = Input.GetAxis("Mouse ScrollWheel");
        

        if (wheelValue == 0) return;
        
        float wheelValueX = Input.mouseScrollDelta.x;
        float wheelValueY = Input.mouseScrollDelta.y;
        print("wheelValue["+wheelValue+"] wheelValueX[ " + wheelValueX + " ] wheelValueY[" + wheelValueY + "]");

        wheelValueG = wheelValueY;
        if (wheelValueY > 0f) // forward
        {
            print("Forward: " + wheelValueY);
            jointRotator.RotateJoint(selectedObject, 10);
        }
        else if (wheelValueY < 0f)
        {
            print("Backward: " + wheelValueY);
            jointRotator.RotateJoint(selectedObject, -10);
        }
    }

    /* Every time you change the model in blender:
     * [ ] 1. save fbx under new number.
     * [ ] 2. delete old model from unity.
     * [ ] 3. drag in new, scale, position.
     * [ ] 4. make gear materials transparent.
     * [ ] 5. hide all gear mesh renderers.
     * [ ] 6. add convexed, triggered, mesh colliders to each joint.
     * [ ] 7. 
     * [ ] 8. 
     * [ ] 9. 
     */

}
