using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public GameObject normalMode;
    public GameObject onDeadline;
    public GameObject PiedMode;

    void Start() // Start Point, Animation Char is Run
    {
        normalMode.SetActive(true);
    }

    void Update()
    {
        bool isPied = GetComponent<Pie>().getPied(); // Check if Character got Pied
        float timer = GetComponent<LevelManager>().Timer; // Check Time

        if (timer < 5)
        {
            normalMode.SetActive(false);
            onDeadline.SetActive(true);
        }

        if (isPied == true)
        {
            normalMode.SetActive(false);
            PiedMode.SetActive(true);
        }

        else if (isPied == false && timer >= 5)
        {
            PiedMode.SetActive(false);
            normalMode.SetActive(true);
        }

        else if (isPied == false && timer < 5)
        {
            PiedMode.SetActive(false);
            onDeadline.SetActive(true);
        }
    }
}
