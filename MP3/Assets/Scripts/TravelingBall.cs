using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBall : MonoBehaviour
{
    public GameObject shadow, line;
    float speed = 0f;
    float lifeSpan = 0f;

    public float d;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0)
        {
            Destroy(gameObject);
        }

        CastShadow();
    }

    public void SetParam(float speed, float lifeSpan)
    {
        this.speed = speed;
        this.lifeSpan = lifeSpan;
    }

    public void CastShadow()
    {
        d = Vector3.Dot(transform.position, TheBarrier.instance.Vn);
        Vector3 v = (d-TheBarrier.instance.D) * -TheBarrier.instance.Vn;
        Vector3 Pon = transform.position + v;
        if(d > 0f && TheBarrier.instance.InRange(Pon))
        {
            if(!shadow.activeInHierarchy)
            {
                shadow.SetActive(true);
                line.SetActive(true);
            }
            shadow.transform.position = Pon;
            shadow.transform.up = TheBarrier.instance.Vn;

            line.transform.position = transform.position + v / 2f;
            line.transform.up = v.normalized;
            line.transform.localScale = new Vector3(0.02f, v.magnitude / 2f, 0.02f);
        }
        else
        {
            shadow.SetActive(false);
            line.SetActive(false);
        }
    }
}
