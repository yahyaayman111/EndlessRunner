using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class segmentPoolingFix : MonoBehaviour
{
    public GameObject[] segments;
    public int poolSize = 5;
    public float segmentLength = 50f;
    private Queue<GameObject> segmentQueue = new Queue<GameObject>();
    public Transform PlayerPostion;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            int rand = Random.Range(0, segments.Length);
            GameObject segment = Instantiate(segments[rand], new Vector3(0, 0, i * segmentLength), Quaternion.identity);
            segmentQueue.Enqueue(segment);
        }

    }

   
    void Update()
    {
        GameObject firstSegment = segmentQueue.Peek();
        if (PlayerPostion.transform.position.z > firstSegment.transform.position.z + segmentLength)
        {
            GameObject ReUsed = segmentQueue.Dequeue();
            float newZ = segmentQueue.Last().transform.position.z + segmentLength;
            ReUsed.transform.position = new Vector3(0, 0, newZ);
            segmentQueue.Enqueue(ReUsed);
        }
    }
}
