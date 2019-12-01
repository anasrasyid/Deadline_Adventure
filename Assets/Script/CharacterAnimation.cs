using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public GameObject normalMode;
    public GameObject onDeadline;
    public GameObject PiedMode;
    public LevelManager levelManagar;
    bool isPied;

    void Start() // Start Point, Animation Char is Run
    {
        normalMode.SetActive(true);
        isPied = false;
    }

    void Update()
    {
        //bool isPied = GetComponent<Pie>().getPied(); // Check if Character got Pied
        //float levelManagar.Timer = GameObject.Find("LevelManager").GetComponent<LevelManager>().levelManagar.Timer; // Check Time

        if (levelManagar.Timer < 10)
        {
            normalMode.SetActive(false);
            onDeadline.SetActive(true);
        }

        if (isPied == true)
        {
            normalMode.SetActive(false);
            PiedMode.SetActive(true);
        }

        else if (isPied == false && levelManagar.Timer >= 10)
        {
            PiedMode.SetActive(false);
            normalMode.SetActive(true);
        }

        else if (isPied == false && levelManagar.Timer < 10)
        {
            PiedMode.SetActive(false);
            onDeadline.SetActive(true);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pied"))
        {
            isPied = true;
            levelManagar.isStunt = true;
            Destroy(collision.gameObject);
            StartCoroutine(ClearPied());
        }
    }

    IEnumerator ClearPied()
    {
        yield return new WaitForSeconds(1f);
        isPied = false;
        levelManagar.isStunt = false;
    }
}
