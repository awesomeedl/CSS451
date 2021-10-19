using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Mouse : MonoBehaviour
{
    // Prefab
    public GameObject aimLinePrefab;

    // EndPt selection
    GameObject selected;
    Color cachedColor;

    // LayerMask for raycasting
    LayerMask layerMask; 
    int normalMask; // for use when nothing is selected
    int planeOnly; // for use when an EndPt is selected

    // Start is called before the first frame update
    void Start()
    {
        // Initialize all the layerMask
        normalMask = LayerMask.GetMask("EndPt", "Wall", "LineSeg");
        planeOnly = LayerMask.GetMask("Wall");
        layerMask = normalMask;
    }

    // Update is called once per frame
    void Update()
    {
        CursorSelect();
    }

    void CursorSelect()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, layerMask.value))
        {
            // Detect Click
            if(Input.GetMouseButtonDown(0))
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
                        Instantiate(aimLinePrefab, new Vector3(0, hit.point.y, hit.point.z), Quaternion.identity);
                        break;
                    case 8: // LineSeg
                        // TODO: Implement lineSeg deletion 
                    default:
                        break;
                }
            }

            // Drag movement
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

    void CreateLine()
    {
        
    }
}
