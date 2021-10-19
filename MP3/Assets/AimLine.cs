using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform start, end;
    public GameObject line;

    [Header("Traveling Ball Param")]
    [Range(0.5f, 4f)]
    public float interval = 1f;
    [Range(0.5f, 15f)]
    public float speed = 5f;
    [Range(1f, 15f)]
    public float lifeSpan = 10f; 

    float nextSpawn = 0f;

    Vector3 l;
    // Start is called before the first frame update
    void Start()
    {

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
