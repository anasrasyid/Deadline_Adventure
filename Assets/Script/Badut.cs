using UnityEngine;
public class Badut : Obstacle
{
    public GameObject pie;
    private GameObject pied;
    public Transform targets;
    public Transform from;

    public override void Action()
    {
        pied = Instantiate(pie, from.position, Quaternion.identity) as GameObject;
        pied.SetActive(true);
        pied.GetComponent<Pie>().target = targets;
    }

    void Start()
    {
        pied = null;
    }

    void Update()
    {
        if (DoTrouble() && pied == null)
        {
            Action();
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
        pied = null;
        time = timer;
    }
}
