using UnityEngine;
using System.Collections;

public abstract class Obstacle : MonoBehaviour
{
    public float timer;
    private float time;
    protected AudioSource audio;
    public AudioClip enterAudio, exitAudio;

    private void Start()
    {
        time = timer;
        audio = GetComponent<AudioSource>();
        //audio.clip = enterAudio;
        //audio.Play();
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

    IEnumerator SoundExit()
    {
        audio.clip = exitAudio;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        gameObject.SetActive(false);
    }

    private void OnMouseDrag()
    {
        if (audio == null)
            gameObject.SetActive(false);
        StartCoroutine(SoundExit());
    }
    
}
