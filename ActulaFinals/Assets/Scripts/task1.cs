using UnityEngine;
public class task1 : MonoBehaviour
{
    public bool p1ready;
    public bool p2ready;

    public GameObject parentZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        parentZone = GameObject.FindGameObjectWithTag("restorationZone");
        parentZone.GetComponent<RestorationZone>().subzones.Add(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        var use1 = GameObject.Find("player").GetComponent<movement>().use;
        var use2 = GameObject.Find("player2").GetComponent<movement>().use;

        if (p1ready && p2ready)
        {
           if(use1.inProgress && use2.inProgress)
            {
                parentZone.GetComponent<RestorationZone>().RestorationPercent += 10;
                parentZone.GetComponent<RestorationZone>().subzones.Remove(gameObject);

                Destroy(gameObject);
                

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("p1"))
        {
            p1ready = true;
        }
        
        if(collision.CompareTag("p2"))
        {
            p2ready = true;
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
