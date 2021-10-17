using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 1f;
    public float minX = 0f;
    public float maxX = 5f;
    private Vector3 direction = Vector3.right;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Vector3.right) 
        {
            if(transform.position.x < maxX)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                meshRenderer.material.color = new Color(0,1,1);
                direction *= -1;
            }
        }
        else
        {
            if(transform.position.x > minX)
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
