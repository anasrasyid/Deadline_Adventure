using UnityEngine;
using UnityEngine.UI;

public class CanvasCondition : MonoBehaviour
{
    public bool isWin;
    public int coin;
    public Text contText, coinText;
    public Sprite[] sprites;
    public Image image;
    
    public void visContText()
    {
        if (isWin)
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

    public void visCoinText()
    {
        coinText.text = coin.ToString();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void xAction()
    {
        if (isWin)
        {
            Debug.Log("Next Level");
        }
        else
        {
            Debug.Log("Restart Level");
        }
    }
}
