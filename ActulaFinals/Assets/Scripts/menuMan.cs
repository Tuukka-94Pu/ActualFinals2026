using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMan : MonoBehaviour
{
    public AudioManager audioManager;

    public void Awake()
    {
       audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void Start()
    {
        if (audioManager != null)
        {
            if (audioManager.musicNames.Contains("bg1"))
            {
                audioManager.PlayMusic("bg1");
                Debug.Log("musiikki sois");
            }
        }
        return;
    }

    public void Play(string scene)
    {
        Click();
        SceneManager.LoadScene(scene); 
    }

    public void Quit()
    {
        Click();
        Debug.Log(":D");
        Application.Quit();
    }

    public void Click()
    {
        if (audioManager != null)
        {
            if(audioManager.soundNames.Contains("click"))
            audioManager.PlaySound("click");
        }
        return;
    }
}
