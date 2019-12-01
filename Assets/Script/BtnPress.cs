using UnityEngine;
using UnityEngine.UI;

public class BtnPress : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    private int _idx = 0;

    public void changeSprites()
    {
        image.sprite = sprites[(++_idx)%2];
    }
}
