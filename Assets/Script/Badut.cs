using UnityEngine;
public class Badut : Obstacle
{
    public GameObject pie;
    private GameObject pied;
    public Transform targets;

    public override void Action()
    {
        pied = Instantiate(pie, this.transform.position, Quaternion.identity) as GameObject;
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
}
