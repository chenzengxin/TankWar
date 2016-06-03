using UnityEngine;
using System.Collections;

public class TankIdleController : MonoBehaviour {

	private new Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        this.rigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.up, Space.World);
    }

    
}
