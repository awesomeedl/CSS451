using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 1f;
    public float minY = 0f;
    public float maxY = 5f;

    public float rotationSpeed = 90f;
    private Vector3 direction = Vector3.up;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Vector3.up) 
        {
            if(transform.position.y < maxY)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                meshRenderer.material.color = new Color(1,0,1);
                direction *= -1;
            }
        }
        else
        {
            if(transform.position.y > minY)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                meshRenderer.material.color = new Color(1,1,1);
                direction *= -1;
            }
        }

        float currentYrot = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0,currentYrot + rotationSpeed * Time.deltaTime,0);
    }
}
