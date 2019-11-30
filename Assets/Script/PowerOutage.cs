using System.Collections;
using UnityEngine;

public class PowerOutage : Obstacle
{
    public GameObject panel;
    public GameObject redPanel;
    private float timeScreen = 2f;
    private float times;
    private bool isClose;

    public override void Action()
    {
        redPanel.SetActive(false);
        panel.SetActive(true);
        isClose = true;
    }

    IEnumerator StartSound()
    {
        while (!isClose)
        {
            redPanel.active = !redPanel.active;
            audio.clip = enterAudio;
            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }
    }
    
    void Start()
    {
        Activeable();
    }

    void Update()
    {
        if (times > 0 && !isClose)
        {
            times -= Time.deltaTime;
            if(times <= 0)
            {
                StopCoroutine(StartSound());
                Action();
            }
        }
        else if(isClose)
        {
            timeScreen -= Time.deltaTime;
            if (timeScreen <= 0)
            {
                panel.SetActive(false);
                timeScreen = 2f;
                isClose = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (audio == null)
            gameObject.SetActive(false);
        else
            StartCoroutine(SoundExit());
    }

    public override void Activeable()
    {
        times = timer;
        isClose = false;
        StartCoroutine(StartSound());
    }
}
