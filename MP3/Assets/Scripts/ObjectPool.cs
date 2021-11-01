using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
This class is written to reduce the amount of time that Instantiate() and Destroy() is called,
hopefully to improve performance by doing all the instantiation upfront
*/
public class ObjectPool : MonoBehaviour
{
    int poolSize = 20;
    Queue<GameObject> q; 
    GameObject ballPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        BallSpawner.objectPool = this;
        ballPrefab = Resources.Load<GameObject>("TravelingBall");
        q = new Queue<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            var g = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            g.SetActive(false);
            q.Enqueue(g);
        }
    }

    public GameObject GetBall()
    {
        if(q.Count == 0)
        {
            for(int i = 0; i < poolSize; i++)
            {
                var g = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
                g.SetActive(false);
                q.Enqueue(g);
            }
            poolSize *= 2;
        }

        var ret = q.Dequeue();
        ret.SetActive(true);
        return ret;
    }

    public void Recycle(GameObject g)
    {
        g.SetActive(false);
        q.Enqueue(g);
    }
}
