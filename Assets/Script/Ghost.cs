using UnityEngine;

public class Ghost : Obstacle
{
    public GameObject screen;
    public AudioClip actionSound;
    private float timeScreen = 2f;
    private Rigidbody2D rb2d;
    private bool scared = false;
    public float speedUp;

    public Transform[] marker;
    private int randomMarker;

    public override void Action()
    {
        screen.SetActive(true);
        audio.clip = actionSound;
        audio.Play();
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        randomMarker = Random.Range(0, marker.Length);    
    }

    void Update()
    {
        
        
        if(DoTrouble() && !screen.active)
        {
            Action();
        }else if (screen.active)
        {
            transform.position = marker[randomMarker].position;

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
