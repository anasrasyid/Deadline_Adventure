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
    private bool _isMute = false;
    private float _audioVolume;

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
        if (!_isMute)
        {
            _isMute = true;
            _audioVolume = AudioListener.volume;
            if (_audioVolume <= 0.0001)
                _audioVolume = 0.5f;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = _audioVolume;
        }
    }
    public void exit()
    {
        Application.Quit();
    }

}
