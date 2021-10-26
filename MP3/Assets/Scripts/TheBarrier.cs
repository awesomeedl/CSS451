using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBarrier : MonoBehaviour
{
    public static TheBarrier instance;
    public float D;
    public Vector3 Vn;
    // Start is called before the first frame update
    void Awake()
    {
        // Setup for static instance
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vn = -transform.forward;
        D = Vector3.Dot(Vn, transform.position);
    }

    public bool InRange(Vector3 pos)
    {
        return (Mathf.Abs((transform.position - pos).magnitude) < transform.localScale.x / 2f);
    }
}
