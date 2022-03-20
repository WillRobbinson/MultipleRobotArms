using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    public Camera camera;
    public Material selectionMaterial;

    private GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
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
                // only repaint previous selection if there was one selected already
                if (SelectionManager.instance.selectedObject != null)
                {
                    print("SelectionManager: [Prev] selectedObject not null");
                    Renderer[] rs = SelectionManager.instance.selectedObject.GetComponentsInChildren<Renderer>();
                    //foreach (Renderer r in rs)
                    //{
                    //Material material = rs[0].material;
                    //material.color = SelectionManager.instance.previouslySelectedObjectMaterial.color;
                    //rs[0].material = material;
                    rs[0].material.CopyPropertiesFromMaterial(SelectionManager.instance.previouslySelectedObjectMaterial);

                    print("SelectionManager: mat set for previous");
                    //}
                    // If there was a previously selected object, then save its material in the prev slot
                    Renderer[] prs = selectedObject.GetComponentsInChildren<Renderer>();
                    SelectionManager.instance.previouslySelectedObjectMaterial.CopyPropertiesFromMaterial(prs[0].material);
                }
                else
                {
                    print("Prev selectedObject was null");
                }

                // the object identified by hit.transform was clicked                

                // new selected object
                selectedObject = hit.transform.gameObject;
                SelectionManager.instance.selectedObject = selectedObject;
                print("Hit: "+selectedObject.name);
                Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();
                //foreach(Renderer r in renderers)
                //{
                //Material m = renderers[0].material;
                //SelectionManager.instance.previouslySelectedObjectMaterial.color = m.color;
                //m.color = selectionMaterial.color;
                //renderers[0].material = m;
                renderers[0].material.CopyPropertiesFromMaterial(selectionMaterial);
                //}
            }
        }
    }
    
}
