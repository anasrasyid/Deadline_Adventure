using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public CanvasCondition canvas;

    void Start()
    {
        canvas.visContText();
        canvas.visCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            canvas.isWin = !canvas.isWin;
            canvas.coin++;
            canvas.visContText();
            canvas.visCoinText();
        }
    }
}
