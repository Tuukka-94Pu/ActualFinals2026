using Unity.VisualScripting;
using UnityEngine;

public class task2 : MonoBehaviour
{
    public bool birdsFollowing;

    public int repeairProgress;

    private float distanceFromBird;

    public GameObject parentZone, bird;

    private GameObject[] allZones;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allZones = GameObject.FindGameObjectsWithTag("restorationZone");

        float smallestDist = 9000;
        foreach (var zone in allZones)
        {
            var distanceto = Vector3.Distance(transform.position, zone.transform.position);
            if (distanceto < smallestDist)
            {
                smallestDist = distanceto;
                parentZone = zone;
            }
            if (!parentZone.GetComponent<RestorationZone>().subzones.Contains(gameObject))

            {
                parentZone.GetComponent<RestorationZone>().subzones.Add(gameObject);
            }
                
        }
    }
        // Update is called once per frame
        void Update()
        {
            distanceFromBird = Vector3.Distance(transform.position, bird.transform.position);
        }
    

    private void BirdFollow(GameObject who)
    {
        bird.transform.parent = who.transform;
        bird.transform.localPosition = new Vector3(0, 3, 0);
        birdsFollowing = true;
        if (AudioManager.instance != null) AudioManager.instance.PlaySound("bird1");
    }

    public void OnUse(GameObject who)
    {
        if(birdsFollowing == false)
        {
            BirdFollow(who);
        }
        else
        {
            if(bird.transform.parent != who.transform) addReapairPercent();
        }
    }


    public void addReapairPercent()
    {
        if (birdsFollowing != true) return;

        if (distanceFromBird < 10) return;

            repeairProgress += 10;

            if(repeairProgress == 50)
            {
            parentZone.GetComponent<RestorationZone>().incereaseCompletion();
            parentZone.GetComponent<RestorationZone>().removeSubzone(gameObject);
            if(AudioManager.instance != null) AudioManager.instance.PlaySound("bird2");

            Destroy(bird);
                Destroy(gameObject);
            
        }
    }
    
}
