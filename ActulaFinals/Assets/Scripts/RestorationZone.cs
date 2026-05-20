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

        if (subzones.Count == 0 && IsCompleted == false)
        {
            IsCompleted = true;

            zonePercent.value = zonePercent.maxValue;
        }
    }

    private IEnumerator waitfORsUBZONES()
    {
        yield return new WaitForSeconds(1);
        zonePercent.maxValue = subzones.Count * 10;
        Debug.Log(subzones.Count + " subzones on" + transform.name);
    }
}
