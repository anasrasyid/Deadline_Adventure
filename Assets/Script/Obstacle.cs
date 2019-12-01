using UnityEngine;
using System.Collections;

public abstract class Obstacle : MonoBehaviour
{
    public float timer;
    protected float time;
    public AudioSource audio;
    public AudioClip enterAudio, exitAudio;

    private void Awake()
    {
        time = timer;
        audio = GetComponent<AudioSource>();
        EnterSound();
    }

    public bool DoTrouble()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = timer;
            return true;
        }
        return false;
    }

    public abstract void Action();


    protected IEnumerator SoundExit()
    {
        audio.clip = exitAudio;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        gameObject.SetActive(false);
    }

    public void EnterSound()
    {
        audio.clip = enterAudio;
        audio.Play();
    }

    public abstract void Activeable();
    
}
