using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject cursor;
    [SerializeField] List<GameObject> shapes;

    Dropdown menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponentInChildren<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        CursorSelect();
    }

    void CursorSelect()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                switch(hit.transform.gameObject.layer)
                {
                    case 6:
                        Destroy(hit.transform.gameObject); break;
                    case 7:
                        cursor.transform.position = new Vector3(0, cursor.transform.localScale.y / 2, 0) + hit.point; break;
                    default:
                        break;
                }
            }
        }
    }

    public void Create()
    {
        if(menu.value > 0)
        {
            Instantiate(shapes[menu.value - 1], cursor.transform.position, Quaternion.identity);
            menu.value = 0;
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
