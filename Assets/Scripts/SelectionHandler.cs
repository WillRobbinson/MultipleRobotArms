using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    public Camera camera;
    public Material selectionMaterial;

    private GameObject selectedObject;

    string convertJoinNameToControllerName(string jointName)
    {
        if ("Shoulder Joint".Equals(jointName)) return "SF_Control";
        if ("BaseShoulder".Equals(jointName)) return "BS_Control";
        if ("UpperArm".Equals(jointName)) return "UA_Control";
        if ("Elbow".Equals(jointName)) return "EB_Control";
        if ("Wrist".Equals(jointName)) return "WR_Control";
        if ("Hand".Equals(jointName)) return "HA_Control";
        if ("PincherBase".Equals(jointName)) return "PB_Control";
        if ("LeftPincher".Equals(jointName)) return "LP_Control";
        if ("RightPincher".Equals(jointName)) return "RP_Control";
        return "Unknown";
    }

    void hideControl(GameObject gameObject)
    {
        string goName = gameObject.name;
        string controllerName = convertJoinNameToControllerName(goName);
        if (!"Unknown".Equals(controllerName))
        {
            GameObject.Find(controllerName).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void showControl(GameObject gameObject)
    {
        string goName = gameObject.name;
        string controllerName = convertJoinNameToControllerName(goName);
        if (!"Unknown".Equals(controllerName))
        {
            GameObject.Find(controllerName).GetComponent<MeshRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // There was already a selected object
                if (SelectionManager.instance.selectedObject != null)
                {
                    hideControl(SelectionManager.instance.selectedObject);
                }
                else
                {
                    print("Prev selectedObject was null");
                }

                // new selected object
                SelectionManager.instance.selectedObject = hit.transform.gameObject;
                showControl(SelectionManager.instance.selectedObject);
            }
        }
    }
}
