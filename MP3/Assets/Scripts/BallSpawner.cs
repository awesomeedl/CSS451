using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Static class to aid the spawing of traveling balls
public static class BallSpawner
{
    public static float interval = 1f;
    public static float speed = 5f;
    public static float lifeSpan = 10f;
    public static float orbitSpeed = 1f;
    public static float orbitRadius = 0f;

    public static ObjectPool objectPool;

    public static void SetParam(float interval, float speed, float lifeSpan, float orbitSpeed, float orbitRadius)
    {
        BallSpawner.interval = interval;
        BallSpawner.speed = speed;
        BallSpawner.lifeSpan = lifeSpan;
        BallSpawner.orbitSpeed = orbitSpeed;
        BallSpawner.orbitRadius = orbitRadius;
    }

    public static void SpawnBall(Vector3 pos, Vector3 lineVector)
    {
        GameObject ball = objectPool.GetBall();
        ball.transform.position = pos;
        ball.transform.up = lineVector.normalized;
        ball.GetComponent<TravelingBall>().SetParam(speed, lifeSpan, orbitSpeed, orbitRadius);
    }

    public static void RemoveBall(GameObject g)
    {
        objectPool.Recycle(g);
    }
}
