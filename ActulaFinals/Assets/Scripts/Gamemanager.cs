using System.Collections;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public int restorationPercent;
    private int maxRestoration;
    private bool hasLose;
    public TMP_Text timer;

    public GameObject[] tasks;
    public Transform[] taskSpawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        restorationPercent = 0;
        foreach (GameObject task in tasks)
        {
            maxRestoration += 10;
            var randSpawn = Random.Range(0, taskSpawns.Length);
            Instantiate(task, taskSpawns[randSpawn].position, Quaternion.identity);
            taskSpawns[randSpawn].gameObject.SetActive(false);
        }

        StartCoroutine(TIMERCOUNTDOWN());
        timer.text = "Time left: 120";  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void endScreen()
    {
        Debug.Log("Game over");
        if(restorationPercent == maxRestoration)
        {
            Debug.Log("You did it");
        }
        else
        {
            Debug.Log("You failed");
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
