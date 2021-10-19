using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBall : MonoBehaviour
{
    float speed = 0f;
    float lifeSpan = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetParam(float speed, float lifeSpan)
    {
        this.speed = speed;
        this.lifeSpan = lifeSpan;
    }
}
