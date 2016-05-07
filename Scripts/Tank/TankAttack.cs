using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {
    private Transform firePosition;
    public GameObject shellPrefab;



	void Awake () {
        firePosition = this.gameObject.transform.Find("FirePosition");
	}
	void Update () {
	    
	}

    public void Fire() {
        GameObject go=GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
        go.transform.parent = this.gameObject.transform;
        
    }
}
