using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : Obstacle
{
    public float timer;
    private float timeNow; 
    public GameObject notif;
    public Sprite[] sprites;
    public GameObject phone;
    public GameObject NotifIcon;
    public Text Pesan;
    private bool phoneUp;
    

    

    private SpriteRenderer _renderer;
    public override void Action()
    {
        _renderer.sprite = sprites[1];

    }

    void Start()
    {
        
        _renderer = GetComponent<SpriteRenderer>();
        Activeable();
       
    }

    void Update()
    {
            timer -= Time.deltaTime;
            if (timer > 0 || notif.active)
            {
                notif.SetActive(true);
                NotifIcon.SetActive(false);
            }
            else if(timer <= 0)
            {
                if(phone.active == false)
                { 
                    NotifIcon.SetActive(true);
                    notif.SetActive(false);
                }
        }
    }
    public void NotifClick()
    {
        if(NotifIcon.active)
        {
            notif.SetActive(true);
            NotifIcon.SetActive(false);
        }
    }
    public void OnClickNotif()
    {
        timer = 0;
        phone.SetActive(true);
        notif.SetActive(false);
        NotifIcon.SetActive(false);
        /*if (audio == null)
            gameObject.SetActive(false);
        else
            StartCoroutine(SoundExit());
        */
    }
    public void balas()
    {
        if(phone.active == true)
        {
            phone.SetActive(false);
            NotifIcon.SetActive(false);
        }
    }

    public override void Activeable()
    {
        _renderer.sprite = sprites[0];
    }
}
