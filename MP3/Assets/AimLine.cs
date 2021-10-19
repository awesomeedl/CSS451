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

    Vector3 l;

    public static void SetParam(float interval, float speed, float lifeSpan)
    {
        AimLine.interval = interval;
        AimLine.speed = speed;
        AimLine.lifeSpan = lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        l = end.position - start.position;
        
        line.transform.position = (end.position + start.position) / 2f;
        line.transform.up = l.normalized;
        line.transform.localScale = new Vector3(0.2f, l.magnitude / 2f, 0.2f);

        if(Time.time > nextSpawn)
        {
            GameObject ball = Instantiate(ballPrefab, start.position, Quaternion.identity);
            ball.transform.up = l.normalized;
            ball.GetComponent<TravelingBall>().SetParam(speed, lifeSpan);
            nextSpawn = Time.time + interval;
        }
    }
}
