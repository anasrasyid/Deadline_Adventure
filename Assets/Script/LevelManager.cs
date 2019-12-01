using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public float Timer;
    public float sizeBar;
    private float _value;
    public Slider barFill;

    private bool _win;
    public bool isStunt;

    public UIManager uIManager;
    private GameManager _gameManager;
    
    void Start()
    {
        barFill.value = 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isStunt = false;
    }

    
    void Update()
    {
        Timer = Timer - Time.deltaTime;
        int minute = ((int)Timer / 60);
        int second = ((int)Timer % 60);
        if(Timer > 0)
        {
            uIManager.visualTime(minute, second);
        }
        else if(barFill.value != 100)
        {
            _win = false;
            Time.timeScale = 0;
            uIManager.ActiveCondPanel();
        }
    }

    public void initBar()
    {
        if (isStunt)
            return;
        barFill.value += sizeBar;
        if(barFill.value == 100)
        {
            _win = true;
            _gameManager.coin += 100;
            Time.timeScale = 0;
            uIManager.ActiveCondPanel();
        }
    }

    public bool getIsWin()
    {
        return _win;
    }

    public GameManager getGM()
    {
        return _gameManager;
    }
}
