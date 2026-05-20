using UnityEngine;
public class task1 : MonoBehaviour
{
    public bool p1ready;
    public bool p2ready;

    private GameObject[] allZones;
    private GameObject parentZone;
    public GameObject endSprite;

    public string endAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allZones = GameObject.FindGameObjectsWithTag("restorationZone");

        float smallestDist = 9000;
        foreach(var zone in allZones)
        {
            var distanceto = Vector3.Distance(transform.position, zone.transform.position);
            if(distanceto < smallestDist)
            {
                smallestDist = distanceto;
                parentZone = zone;
            }
        }


        parentZone.GetComponent<RestorationZone>().subzones.Add(gameObject);


        if (endSprite != null) endSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var p1 = GameObject.Find("player").GetComponent<movement>();
        var p2 = GameObject.Find("player2").GetComponent<movement>();

        if (p1ready && p2ready)
        {
            


            var use1 = p1.use;
            var use2 = p2.use;

            p1.useInfo.text = "Smash use";
            p2.useInfo.text = "at the same time";

            if (use1.inProgress && use2.inProgress)
            {
                parentZone.GetComponent<RestorationZone>().incereaseCompletion();
                parentZone.GetComponent<RestorationZone>().removeSubzone(gameObject);

                if (endSprite != null) endSprite.SetActive(true);

               if(AudioManager.instance != null) if (endAudio != null) AudioManager.instance.PlaySound(endAudio);

                p1.useInfo.text = "";
                p2.useInfo.text = "";

                Destroy(gameObject);
                

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("p1"))
        {
            p1ready = true;
            collision.GetComponent<movement>().useInfo.text = "Wait for other player";
        }
        
        if(collision.CompareTag("p2"))
        {
            p2ready = true;
            collision.GetComponent<movement>().useInfo.text = "Wait for other player";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("p1"))
        {
            p1ready = false;
        }

        if(other.CompareTag("p2"))
        {
            p2ready = false;
        }
    }

}
