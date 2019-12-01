using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    public float coin;
    public float level;
    public float coffe;
    
    void Start()
    {
        if(instance == null)
        {
            instance = gameObject;
            restartState();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void restartState()
    {
        coin = 0;
        level = 1;
        coffe = 0;
    }

    public bool canBuyCoffe()
    {
        return coin >= 100;
    }
    
    public void adddingCoffe()
    {
        coin -= 100;
        coffe += 1;
    }
}
