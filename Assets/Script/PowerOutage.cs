using System.Collections;
using UnityEngine;

public class PowerOutage : Obstacle
{
    public GameObject panel;
    public GameObject efector;
    private float timeScreen = 1f;

    public override void Action()
    {
        panel.SetActive(true);
    }

    IEnumerator StartSound()
    {
        audio.clip = enterAudio;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
    
    void Start()
    {
        efector.GetComponent<Animator>().SetBool("outage", true);
        StartCoroutine(StartSound());
    }

    void Update()
    {
        if (DoTrouble())
        {
            efector.GetComponent<Animator>().SetBool("outage", false);
            StopCoroutine(StartSound());
            panel.SetActive(true);
        }else if (panel.active)
        {
            timeScreen -= Time.deltaTime;
            if (timeScreen <= 0)
            {
                panel.SetActive(false);
                timeScreen = 1f;
                gameObject.SetActive(false);
            }
        }
    }
}
