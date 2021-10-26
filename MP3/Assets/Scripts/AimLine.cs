using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public static float interval = 1f;
    public static float speed = 5f;
    public static float lifeSpan = 10f; 

    public GameObject ballPrefab;
    public Transform start, end;
    public GameObject line;

    float nextSpawn = 0f;

    Vector3 v;

    public GameObject reflectLine;

    public static void SetParam(float interval, float speed, float lifeSpan)
    {
        AimLine.interval = interval;
        AimLine.speed = speed;
        AimLine.lifeSpan = lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        v = end.position - start.position;
        
        line.transform.position = (end.position + start.position) / 2f;
        line.transform.up = v.normalized;
        line.transform.localScale = new Vector3(0.2f, v.magnitude / 2f, 0.2f);

        if(Time.time > nextSpawn)
        {
            GameObject ball = Instantiate(ballPrefab, start.position, Quaternion.identity);
            ball.transform.up = v.normalized;
            ball.GetComponent<TravelingBall>().SetParam(speed, lifeSpan);
            nextSpawn = Time.time + interval;
        }

        

        Reflect();
    }

    void Reflect()
    {
        
        float d = (TheBarrier.instance.D - Vector3.Dot(start.position, TheBarrier.instance.Vn)) / Vector3.Dot(v, TheBarrier.instance.Vn);

        Vector3 projectedV = v * d;
        Vector3 reflectPt = start.transform.position + projectedV;

        if(TheBarrier.instance.InRange(reflectPt))
        {

            Vector3 reflection = 2f * (Vector3.Dot(-projectedV, TheBarrier.instance.Vn) * TheBarrier.instance.Vn) + projectedV;
            if(!reflectLine.activeInHierarchy)
            {
                reflectLine.SetActive(true);
            }

            reflectLine.transform.position = reflectPt + reflection / 2f;
            reflectLine.transform.up = reflection.normalized;
            reflectLine.transform.localScale = new Vector3(0.2f, reflection.magnitude / 2f, 0.2f);
        }
        else
        {
            reflectLine.SetActive(false);
        }
    }
}
