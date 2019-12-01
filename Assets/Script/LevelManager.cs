using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelManager : MonoBehaviour
{
    public float Timer;
    public float sizeBar;
    private float _value;
    public Slider barFill;

    private bool _win;
    public bool isStunt;
    public float timeBoost;
    private bool isBoost;
    private float _sizeBar;
    private bool _isSave;

    public UIManager uIManager;
    private GameManager _gameManager;

    void Start()
    {
        barFill.value = 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isStunt = false;
        isBoost = true;
        _sizeBar = sizeBar;
        _isSave = false;
    }


    void Update()
    {
        Timer = Timer - Time.deltaTime;
        int minute = ((int)Timer / 60);
        int second = ((int)Timer % 60);
        if (Timer > 0)
        {
            uIManager.visualTime(minute, second);
        }
        else if (barFill.value != 100)
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
        barFill.value += _sizeBar;
        if (barFill.value == 100)
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

    public void PowerUp()
    {
        if (isBoost && _gameManager.coffe > 0)
        {
            isBoost = false;
            _gameManager.coffe--;
            StartCoroutine(PowerTimeUP());
        }
    }

    IEnumerator PowerTimeUP()
    {
        _sizeBar = 2f * sizeBar;
        yield return new WaitForSeconds(timeBoost);
        isBoost = true;
        _sizeBar = sizeBar;
    }

    public void setSave() => _isSave = true;

    public void DelProgress()
    {
        if (_isSave)
            return;
        barFill.value = 0;
        _isSave = false;
    }
}
