using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator2 : MonoBehaviour
{
    public GameObject[] Segments;
    

    [SerializeField] int zPos = 0;
    private bool IsGenerating = false;
    [SerializeField] int segmentNumber =0;

    private void Update()
    {
        if (IsGenerating == false)
        {
            IsGenerating = true;
            StartCoroutine(SegmantGenerator());
        }

        
    }


    IEnumerator SegmantGenerator() 
    {
        segmentNumber = Random.Range(0, Segments.Length - 1);
        zPos += 50;
        Instantiate(Segments[segmentNumber], new Vector3(0, 0, zPos), Quaternion.identity);
        yield return new WaitForSeconds(3f);
        IsGenerating = false;
    }
}
