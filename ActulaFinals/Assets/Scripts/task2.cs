using Unity.VisualScripting;
using UnityEngine;

public class task2 : MonoBehaviour
{
    public bool birdsFollowing;

    public int repeairProgress;

    private float distanceFromBird;

    public GameObject parentZone,bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repeairProgress = 0;
        parentZone = GameObject.FindGameObjectWithTag("restorationZone");
        parentZone.GetComponent<RestorationZone>().subzones.Add(gameObject);
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
            parentZone.GetComponent<RestorationZone>().RestorationPercent += 10;
            parentZone.GetComponent<RestorationZone>().subzones.Remove(gameObject);
            Destroy(bird);
                Destroy(gameObject);
            
        }
    }
    
}
