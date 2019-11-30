using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : Obstacle
{
    public GameObject popUp;
    public Sprite[] sprites;

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
        if (DoTrouble())
        {
            Action();
        }
    }

    private void OnMouseDrag()
    {
        if (_renderer.sprite == sprites[0])
        {
            popUp.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            _renderer.sprite = sprites[0];
        }
        /*if (audio == null)
            gameObject.SetActive(false);
        else
            StartCoroutine(SoundExit());
        */
    }

    public override void Activeable()
    {
        _renderer.sprite = sprites[0];
    }
}
