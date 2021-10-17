using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public float speed = 1f;
    public float minZ = 0f;
    public float maxZ = 5f;
    private Vector3 direction = Vector3.forward;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Vector3.forward) 
        {
            if(transform.position.z < maxZ)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                meshRenderer.material.color = new Color(1,1,0);
                direction *= -1;
            }
        }
        else
        {
            if(transform.position.z > minZ)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                meshRenderer.material.color = new Color(1,1,1);
                direction *= -1;
            }
        }
    }
}
