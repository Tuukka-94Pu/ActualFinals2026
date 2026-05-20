using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestorationZone : MonoBehaviour
{
    public int RestorationPercent;

    public Slider zonePercent;

    public bool IsCompleted;

    private int subzoneCount;

    public List<GameObject> subzones = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waitfORsUBZONES());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       
                



    }

    public void incereaseCompletion()
    {

        RestorationPercent += 10;
        zonePercent.value = RestorationPercent;
    }

    public void removeSubzone(GameObject zone)
    {

        subzones.Remove(zone);

        subzoneCount--;

        foreach(GameObject zon in subzones)
        {
            if(zon == null)
            {
                subzones.Remove(zon);
            }
        }

        if ((subzones.Count == 0 || subzoneCount == 0 )&& IsCompleted == false)
        {
            IsCompleted = true;

            zonePercent.value = zonePercent.maxValue;

            GameObject.Find("GameManager").GetComponent<Gamemanager>().restoredZones++;
        }
    }

    private IEnumerator waitfORsUBZONES()
    {
        yield return new WaitForSeconds(1);
        zonePercent.maxValue = subzones.Count * 10;
        subzoneCount = subzones.Count;
        Debug.Log(subzones.Count + " subzones on" + transform.name);
    }
}
