using UnityEngine;
using UnityEngine.UI;

public class CanvasCondition : MonoBehaviour
{
    public bool isWin;
    public int coin;
    public Text contText, coinText, xText;
    
    public void visContText()
    {
        if (isWin)
        {
            contText.text = "Menang";
            xText.text = "Next"; 
        }
        else
        {
            contText.text = "Kalah";
            xText.text = "Restart";
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
