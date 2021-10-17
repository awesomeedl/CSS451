using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Controller : MonoBehaviour
{
    public GameObject selected;

    public XformControl xform;

    Material cachedMat;

    public Material transparent;

    public void OnSelect(GameObject selection)
    {
        Deselect();

        xform.UpdateUI(selection);
        selected = selection;
        cachedMat = selected.GetComponent<MeshRenderer>().material;
        selected.GetComponent<MeshRenderer>().material = transparent;
        selected.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 0f, 0.5f);

        
    }

    public void Deselect()
    {
        if(selected != null)
        {
            selected.GetComponent<MeshRenderer>().material = cachedMat;
            selected = null;
        }
    }

    public void ChangeTranslation(Vector3 translation)
    {
        selected.transform.localPosition = translation;
    }

    public void ChangeScale(Vector3 scale)
    {
        selected.transform.localScale = scale;
    }

    public void ChangeRotation(Vector3 rotation)
    {
        selected.transform.localRotation = Quaternion.Euler(rotation);
    }

    public void Create()
    {
        
        if(selected == null)
        {
            if(menu.value > 0)
            {
                GameObject newGO = Instantiate(shapes[menu.value - 1], new Vector3(1,1,1), Quaternion.identity);
                newGO.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
        else
        {
            if(menu.value > 0)
            {
                Vector3 location = selected.transform.localPosition + new Vector3(1, 1, 1);
                GameObject newGO = Instantiate(shapes[menu.value - 1]);
                newGO.transform.parent = selected.transform;
                newGO.transform.localPosition = location;

                if(selected.transform.childCount > 0)
                {
                    Material siblingMat = selected.transform.GetChild(0).GetComponent<MeshRenderer>().material;
                    
                    
                    newGO.GetComponent<MeshRenderer>().material = siblingMat;
                }
            }
        }

        menu.value = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorSelect();
    }
}
