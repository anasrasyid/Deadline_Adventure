using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button Play;
    [SerializeField] private Button Coffee;
    [SerializeField] private Button Mute;
    [SerializeField] private Button Exit;
    [SerializeField] private string sceneGameplay;

    // Start is called before the first frame update
    public void play()
    {
        SceneManager.LoadScene(sceneGameplay);
    }
    public void coffee()
    {

    }
    public void mute()
    {

    }
    public void exit()
    {
        Application.Quit();
    }

}
