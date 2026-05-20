using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private int restoredZones;
    private bool hasLose;
    public TMP_Text timer;

    public GameObject[] tasks;
    private GameObject[] taskSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(Taskspawn());

        StartCoroutine(TIMERCOUNTDOWN());
        timer.text = "Time left: 180";  
    }

    // Update is called once per frame
    void Update()
    { 
        if(restoredZones >= 3)
        {
            SceneManager.LoadScene("winScene");
        }
    }

    private void endScreen()
    {
      
        if(restoredZones >= 3)
        {
            SceneManager.LoadScene("winScene");
        }
        else
        {
            AudioManager.instance.PlayMusic("losebg");
            SceneManager.LoadScene("loseScene");
        }
    }

    private IEnumerator Taskspawn()
    {
        foreach (GameObject task in tasks)
        {
            taskSpawns = GameObject.FindGameObjectsWithTag("taskSpawn");
            yield return new WaitForSeconds(0.05f);
            var randSpawn = Random.Range(0, taskSpawns.Length);

            while (taskSpawns[randSpawn] == null)
            {
                randSpawn = Random.Range(0, taskSpawns.Length);
            }

            Instantiate(task, taskSpawns[randSpawn].transform.position, Quaternion.identity);
            Destroy(taskSpawns[randSpawn]);
           
        }
    }

    private IEnumerator TIMERCOUNTDOWN()
    {
        var TIME = 180;

        while (TIME > 0)
        {
            yield return new WaitForSeconds(1);
            TIME--;
            timer.text = "Time left: " + TIME + " seconds";
        }
        endScreen();
    }
}
