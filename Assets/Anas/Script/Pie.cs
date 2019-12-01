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
        speed += 0.1f;
        float distCovered = (Time.time - startTime) * speed;
        float fractionJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, target.position,fractionJourney);

        transform.localScale = Vector3.Lerp(transform.localScale,new Vector3(0.5f,0.5f,0f),fractionJourney);
    }

    private void OnMouseDown()
    {
        if(transform.position != target.position)
        {
            Destroy(gameObject);
        }
    }
}
