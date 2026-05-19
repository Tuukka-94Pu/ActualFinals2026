using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public int restorationPercent;
    private int maxRestoration;
    private bool hasLose;
    public TMP_Text timer;

    public GameObject[] tasks;
    private GameObject[] taskSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        restorationPercent = 0;

        StartCoroutine(Taskspawn());

        StartCoroutine(TIMERCOUNTDOWN());
        timer.text = "Time left: 120";  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void endScreen()
    {
      
        if(restorationPercent == maxRestoration)
        {
            SceneManager.LoadScene("winScene");
        }
        else
        {
            SceneManager.LoadScene("loseScene");
        }
    }

    private IEnumerator Taskspawn()
    {
        foreach (GameObject task in tasks)
        {
            taskSpawns = GameObject.FindGameObjectsWithTag("taskSpawn");
            yield return new WaitForSeconds(0.01f);
            maxRestoration += 10;
            var randSpawn = Random.Range(0, taskSpawns.Length);
            Instantiate(task, taskSpawns[randSpawn].transform.position, Quaternion.identity);
            Destroy(taskSpawns[randSpawn]);
           
        }
    }

    private IEnumerator TIMERCOUNTDOWN()
    {
        var TIME = 120;

        while (TIME > 0)
        {
            yield return new WaitForSeconds(1);
            TIME--;
            timer.text = "Time left: " + TIME;
        }
        endScreen();
    }
}
