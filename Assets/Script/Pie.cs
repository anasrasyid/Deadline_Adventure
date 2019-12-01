using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    public Transform target;
    public float speed;
    private float startTime;
    private float journeyLength;
    private bool pied = false;

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
    }

    private void OnMouseDown()
    {
        if(transform.position != target.position)
        {
            Destroy(gameObject);
        }
        else if (transform.position == target.position)
        {
            setPied(true);
            // Delay for 1 Second and cannot work
            setPied(false);
        }
    }

    public void setPied(bool isPied)
    {
        this.pied = isPied;
    }

    public bool getPied()
    {
        return pied;
    }
}
