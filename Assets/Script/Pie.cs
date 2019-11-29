using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    public Transform target;
    public float speed;
    private float startTime;
    private float journeyLength;

    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, target.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, target.position,fractionJourney);
    }

    private void OnMouseDown()
    {
        if(transform.position != target.position)
        {
            Destroy(gameObject);
        }
    }
}
