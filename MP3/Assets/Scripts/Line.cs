using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform start, end;
    public GameObject line, reflectLine;
    public float lineThickness = 0.2f;

    float nextSpawn = 0f;
    
    Vector3 v; // Vector that represents the line
    // Variables for reflection
    Vector3 projectedV, reflectPt, reflection;

    // Update is called once per frame
    void Update()
    {
        v = end.position - start.position;

        if(Time.time > nextSpawn)
        {
            BallSpawner.SpawnBall(start.position, v);
            nextSpawn = Time.time + BallSpawner.interval;
        }

        MyUtil.DrawLine(line.transform, start, end, lineThickness);
        Reflect();
    }

    void Reflect()
    {
        projectedV = v * (TheBarrier.instance.D - Vector3.Dot(start.position, TheBarrier.instance.Vn)) / Vector3.Dot(v, TheBarrier.instance.Vn);
        reflectPt = start.transform.position + projectedV;

        if(TheBarrier.InRange(reflectPt))
        {

            reflection = 2f * (Vector3.Dot(-projectedV, TheBarrier.instance.Vn) * TheBarrier.instance.Vn) + projectedV;
            if(!reflectLine.activeInHierarchy)
            {
                reflectLine.SetActive(true);
            }

            MyUtil.DrawLine(reflectLine.transform, reflectPt, reflection, lineThickness);
        }
        else
        {
            reflectLine.SetActive(false);
        }
    }
}
