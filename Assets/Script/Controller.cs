using UnityEngine;

public class Controller : MonoBehaviour
{
    public LevelManager level;
    public GameObject effector;
    private void OnMouseDown()
    {
        if(effector.active)
            level.setSave();
    }
}
