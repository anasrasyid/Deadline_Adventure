using UnityEngine;
using System.Collections;
public class Badut : Obstacle
{
    public GameObject pie;
    private GameObject pied;
    public Transform targets;
    public Transform from;
    private Animator _animator;

    public override void Action()
    {
        pied = Instantiate(pie, from.position, Quaternion.identity) as GameObject;
        pied.SetActive(true);
        pied.GetComponent<Pie>().target = targets;
    }

    void Start()
    {
        pied = null;
        _animator = GetComponent<Animator>();
    }

    IEnumerator ThrowPie()
    {
        _animator.SetTrigger("Pie");
        yield return new WaitForSeconds(0.420f);
        Action();
        time = timer;
        StartCoroutine(SoundExit());
    }

    void Update()
    {
        if (DoTrouble())
        {
            StartCoroutine(ThrowPie());
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
