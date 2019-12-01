using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwannner : MonoBehaviour
{
    public GameObject obstacle;
    private float times;

    private void Start()
    {
        times = Random.RandomRange(1, 3);
        Debug.Log(times);
        StartCoroutine(Genearete());
    }

    IEnumerator Genearete()
    {
        while (true)
        {
            yield return new WaitForSeconds(times);
            obstacle.SetActive(true);
            obstacle.GetComponent<Obstacle>().Activeable();
            yield return new WaitForSeconds(obstacle.GetComponent<Obstacle>().timer + 4f);
            obstacle.SetActive(false);
        }

    }
}
