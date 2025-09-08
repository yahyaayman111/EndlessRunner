using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolGen : MonoBehaviour
{
    public GameObject[] segments;
    public Transform player;
    private int segmentSize = 5;
    private float segmentLength = 50;

    private Queue<GameObject> segmentQueue = new Queue<GameObject>();


    private void Start()
    {
        for (int i = 0; i < segmentSize; i++)
        {
            int rand = Random.Range(0, segments.Length);
            GameObject segment = Instantiate(segments[rand], new Vector3(0, 0, i * segmentLength), Quaternion.identity);
            segmentQueue.Enqueue(segment);
        }
    }

    private void Update()
    {
        GameObject FirstSegment = segmentQueue.Peek();
        if (player.transform.position.z > FirstSegment.transform.position.z + segmentLength)
        {
            GameObject reUsed = segmentQueue.Dequeue();
            float newZ = segmentQueue.Last().transform.position.z + segmentLength;
            reUsed.transform.position = new Vector3(0, 0, newZ);
            segmentQueue.Enqueue(reUsed);
        }
    }


}


