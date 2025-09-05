using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SegmentGeneratorPooling : MonoBehaviour
{
    public GameObject[] segmentPrefabs;
    public int poolSize = 5;
    public float segmentLength = 50f;

    private Queue<GameObject> activeSegments = new Queue<GameObject>();
    [SerializeField] private Transform player;

    void Start()
    {
        // Create pool
        for (int i = 0; i < poolSize; i++)
        {
            int rand = Random.Range(0, segmentPrefabs.Length);
            GameObject obj = Instantiate(segmentPrefabs[rand], new Vector3(0, 0, i * segmentLength), Quaternion.identity);
            activeSegments.Enqueue(obj);
        }
    }

    void Update()
    {
        // Check if player passed the first segment
        GameObject firstSegment = activeSegments.Peek();

        if (player.position.z - firstSegment.transform.position.z > segmentLength)
        {
            // Reuse this segment
            GameObject reused = activeSegments.Dequeue();

            // Move it to the end
            float newZ = activeSegments.Last().transform.position.z + segmentLength;
            reused.transform.position = new Vector3(0, 0, newZ);

            activeSegments.Enqueue(reused);
        }
    }
}
