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

    public static bool InRange(Vector3 pos)
    {
        return (Mathf.Abs((instance.transform.position - pos).magnitude) < instance.transform.localScale.x / 2f);
    }

    public static bool Infront(Vector3 pos)
    {
        return Vector3.Dot(pos, instance.Vn) > instance.D;
    }
}
