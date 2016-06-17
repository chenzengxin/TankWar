using UnityEngine;
using System.Collections;

public class InfluenceHeal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player")
        {
            collider.gameObject.SendMessage("GetHeal",20);
        }
        Debug.Log("Heal");
        Destroy(this.gameObject);
    }
}
