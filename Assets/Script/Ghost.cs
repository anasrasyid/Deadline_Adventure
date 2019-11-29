using UnityEngine;

public class Ghost : Obstacle
{
    public GameObject screen;
    private float timeScreen = 1f;

    public override void Action()
    {
        screen.SetActive(true);
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
                timeScreen = 1f;
            }
        }
    }
}
