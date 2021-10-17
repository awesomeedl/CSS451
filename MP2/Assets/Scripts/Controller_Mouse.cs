using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public partial class Controller : MonoBehaviour
{
    [SerializeField] List<GameObject> shapes;

    Dropdown menu;
    //Start is called before the first frame update
    void Start()
    {
        menu = GetComponentInChildren<Dropdown>();
    }

    void CursorSelect()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    switch(hit.transform.gameObject.layer)
                    {
                        case 6:
                            OnSelect(hit.transform.gameObject);
                            break;
                        default:
                            Deselect();
                            break;
                    }
                }
            }
        }
    }



    // public void Pause()
    // {
    //     Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    // }
}
