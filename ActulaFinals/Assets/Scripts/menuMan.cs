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
            audioManager.PlaySound("click");
        }
        return;
    }
}
