using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private Controller control;

    public float Timer;
    public float coin;
    public float sizeBar;
    public float Coin;

    private bool win;
    public Text timeText;
    public Slider barFill;
    public Text coinText;

    public Image Tab;
    public Button Resume;
    public Button Restart;
    public Button Quit;

    void Start()
    {
        control = GetComponent<Controller>();
        barFill = GameObject.Find("Slider").GetComponent<Slider>();
        Timer = Time.time;
        coinText.text = coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Timer - Time.time;

        string minute = ((int)t / 60).ToString();
        string second = (t % 60).ToString("f0");

        timeText.text = minute + " : " + second;
    }
    public void initBar()
    {

        barFill.value += sizeBar;
        if(barFill.value == barFill.maxValue)
        {
            CoinIn();
        }

    }
    public void CoinIn()
    {
        float c = coin + 100f;
        coinText.text = c.ToString();
    }
    public void OnClickPause()
    {
        Tab.gameObject.SetActive(true);
    }
    public void OnClickResume()
    {
        Tab.gameObject.SetActive(false);
    }
    public void OnClickRestart()
    {
        Tab.gameObject.SetActive(false);
        barFill.value = 0;
    }
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Menu");
    }
    
    
    


}
