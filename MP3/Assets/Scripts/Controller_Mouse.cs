using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class Controller : MonoBehaviour
{
    // EndPt selection
    GameObject selected;
    Color cachedColor;

    // LayerMask for raycasting
    LayerMask layerMask; 
    int normalMask; // for use when nothing is selected
    int planeOnly; // for use when an EndPt is selected

    // Called at Start() to initialize layermasks
    void InitLayerMask()
    {
        // Initialize all the layerMask
        normalMask = LayerMask.GetMask("EndPt", "Wall", "LineSeg");
        planeOnly = LayerMask.GetMask("Wall");
        layerMask = normalMask;
    }

    void CursorSelect()
    {
        bool clicked = Input.GetMouseButtonDown(0);

        if(selected == null && !clicked) return; // Only do raycast when an EndPt is selected or the mouse is clicked
        
        RaycastHit hit;                                          // If raycast didnt' hit anything skip to next frame
        if(!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask.value)) return;

        // Handle mouse click ----------------------------------------------------------------------------------
        if(clicked && !EventSystem.current.IsPointerOverGameObject())
        {
            switch(hit.transform.gameObject.layer)
            {
                case 6: // End Point
                    selected = hit.transform.gameObject;
                    cachedColor = selected.GetComponent<MeshRenderer>().material.color;
                    selected.GetComponent<MeshRenderer>().material.color = Color.black;
                    // Change the raycast to only detect walls (ignore other objects)
                    layerMask.value = planeOnly;
                    break;
                case 7: // Wall
                    CreateAimLine(hit.point.y, hit.point.z);
                    break;
                case 8: // LineSeg
                    // TODO: Implement lineSeg deletion 
                default:
                    break;
            }
        }

        // Drag movement --------------------------------------------------------------------------------------
        if(selected != null)
        {
            // Move the EndPt accordingly
            selected.transform.position = hit.point;
            
            // Detect release
            if(Input.GetMouseButtonUp(0))
            {
                selected.GetComponent<MeshRenderer>().material.color = cachedColor;
                selected = null;
                // revert back to normal raycast detection
                layerMask.value = normalMask;
            }
        }
    }
}
