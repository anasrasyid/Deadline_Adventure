using UnityEngine;

public class Ghost : Obstacle
{
    public GameObject screen;
    public AudioClip actionSound;
    private float timeScreen = 2f;

    public override void Action()
    {
        screen.SetActive(true);
        audio.clip = actionSound;
        audio.Play();
    }

    void Update()
    {
        if(DoTrouble() && !screen.active)
        {
            Action();
        }else if (screen.active)
        {
            timeScreen -= Time.deltaTime;
            if(timeScreen <= 0)
            {
                screen.SetActive(false);
                timeScreen = 2.5f;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDrag()
    {
        StartCoroutine(SoundExit());
    }

    public override void Activeable()
    {
        time = timer;
        EnterSound();
    }
}
