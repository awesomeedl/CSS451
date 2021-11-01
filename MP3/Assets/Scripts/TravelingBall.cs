using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingBall : MonoBehaviour
{
    public GameObject shadow, line;
    float speed = 0f, lifeSpan = 0f;
    Vector3 contactPt, v, Pon, velocity;

    // Variables for orbiting
    Vector3 i, j, k;
    float t0, t;
    float orbitSpeed, orbitRadius;


    // Update is called once per frame
    void Update()
    {
        // Point on ball that is closeset/perpendicular to the plane 
        contactPt = transform.position - TheBarrier.instance.Vn * transform.localScale.y * 0.5f;
        
        // Noraml vector from the ball to the plane 
        v = (Vector3.Dot(transform.position, TheBarrier.instance.Vn) - TheBarrier.instance.D) * -TheBarrier.instance.Vn;
        
        // Position of the ball projected on the plane
        Pon = transform.position + v;

        // Velocity of the ball
        velocity = speed * transform.up;
        
        t = Time.time - t0;
        velocity = new Vector3(
            -i.x * orbitRadius * orbitSpeed * Mathf.Sin(orbitSpeed * t) + j.x * orbitRadius * orbitSpeed * Mathf.Cos(orbitSpeed * t) + velocity.x,
            -i.y * orbitRadius * orbitSpeed * Mathf.Sin(orbitSpeed * t) + j.y * orbitRadius * orbitSpeed * Mathf.Cos(orbitSpeed * t) + velocity.y,
            -i.z * orbitRadius * orbitSpeed * Mathf.Sin(orbitSpeed * t) + j.z * orbitRadius * orbitSpeed * Mathf.Cos(orbitSpeed * t) + velocity.z
        );

        transform.position += velocity * Time.deltaTime;

        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0)
        {
            BallSpawner.RemoveBall(gameObject);
        }

        CastShadow();
        Bounce();
    }

    public void SetParam(float speed, float lifeSpan, float orbitSpeed, float orbitRadius)
    {
        this.speed = speed;
        this.lifeSpan = lifeSpan;
        this.orbitSpeed = orbitSpeed;
        this.orbitRadius = orbitRadius;

        i = transform.right;
        j = transform.forward;

        t0 = Time.time;

        transform.position += orbitRadius * i;
        //Debug.Log(transform.right + " " + transform.forward + " " + transform.up);
    }

    void CastShadow()
    {
        if(TheBarrier.Infront(contactPt)  && TheBarrier.InRange(Pon))
        {
            if(!shadow.activeInHierarchy)
            {
                shadow.SetActive(true);
                line.SetActive(true);
            }
            shadow.transform.position = Pon - v.normalized * 0.05f;
            shadow.transform.up = TheBarrier.instance.Vn;
            float scale = (1f - (v.magnitude / 34f)) * (1f - (v.magnitude / 34f));
            shadow.transform.localScale = new Vector3(scale, 0.1f, scale);

            MyUtil.DrawLine(line.transform, transform.position, v, 0.02f);
        }
        else
        {
            shadow.SetActive(false);
            line.SetActive(false);
        }
    }

    void Bounce()
    {
        if(TheBarrier.Infront(transform.position) && !TheBarrier.Infront(contactPt) 
            && Vector3.Dot(velocity, TheBarrier.instance.Vn) < 0
            && TheBarrier.InRange(Pon)) // Going to collide
        {
            velocity = 2f * (Vector3.Dot(-velocity, TheBarrier.instance.Vn) * TheBarrier.instance.Vn) + velocity;
            transform.up = velocity.normalized;

            i = transform.right;
            j = transform.forward;
        }
    }
}
