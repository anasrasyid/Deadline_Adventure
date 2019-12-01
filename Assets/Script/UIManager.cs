using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public Text coinText;

    public GameObject pausePanel;
    public LevelManager level;

    public Text contText;
    public Sprite[] sprites;
    public Image image;
    public GameObject CondPanel;

    public void visualCoin(float c)
    {
        coinText.text = ((int)c).ToString() + " Coin";
    }

    public void visualTime(int minute,int second)
    {
        timeText.text = string.Format("{0:00} : {1:00}", minute, second);
    }

    public void OnClickPause()
    {
        pausePanel.active = true;
        Time.timeScale = 0;
    }

    public void OnClickResume()
    {
        pausePanel.active = false;
        Time.timeScale = 1;
    }

    /*public void OnClickRestart()
    {
        Tab.gameObject.SetActive(false);
        barFill.value = 0;
    }*/

    public void OnMainMenu()
    {
        Time.timeScale = 1;
        level.getGM().restartState();
        SceneManager.LoadScene("Menu");
    }

    public void ActiveCondPanel()
    {
        pausePanel.SetActive(false);
        CondPanel.SetActive(true);
        visualCoin(level.getGM().coin);
        if (level.getIsWin())
        {
            contText.text = "Menang";
            image.sprite = sprites[0];
        }
        else
        {
            contText.text = "Kalah";
            image.sprite = sprites[1];
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void xAction()
    {
        Time.timeScale = 1;
        if (level.getIsWin())
        {
            Debug.Log("Next Level");
            level.getGM().level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Restart Level");
            OnMainMenu();
        }
    }

    public void visualCofee()
    {
        if (level.getGM().canBuyCoffe())
        {
            level.getGM().adddingCoffe();
            visualCoin(level.getGM().coin);
        }
    }
}
