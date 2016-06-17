using UnityEngine;
using System.Collections;

public class InfluenceSpeedy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Speedy");
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<TankController>().SetSpeedy();
        }
        Destroy(this.gameObject);
    }



}
