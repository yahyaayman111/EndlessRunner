using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segments;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = true;
    [SerializeField] int segmentNum;
    // Start is called before the first frame update
    void Update()
    {
        if (creatingSegment)
        {
            creatingSegment = false;
            StartCoroutine(SectionGen());
        }
    }
    IEnumerator SectionGen()
    {
        segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        //segments[segmentNum].transform.position = new Vector3 (0, 0, zPos);
        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSegment = true;
    }
}
