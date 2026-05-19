using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestorationZone : MonoBehaviour
{
    public int RestorationPercent;

    public Slider zonePercent;

    public bool IsCompleted;

    public List<GameObject> subzones = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zonePercent.maxValue = subzones.Count * 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        zonePercent.value = RestorationPercent;

        if (subzones.Count == 0 && IsCompleted == false)
        {
            IsCompleted = true;
            Debug.Log("Zone completed");
        }



    }
}
