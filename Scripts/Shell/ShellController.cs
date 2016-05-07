using UnityEngine;
using System.Collections;


public enum ShellState {
    Default,Large,Crazy
}
public class ShellController : MonoBehaviour {
    private float speed=20;
    private Rigidbody rigidbody;
    public GameObject shellExplosion;
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    // Use this for initialization
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
	}

    void Start() {
        this.rigidbody.velocity = this.transform.forward*Speed;
    }
	// Update is called once per frame
	void Update () {
	    
	}


    public void OnTriggerEnter(Collider collider) {
        ShowExplosion();
        
    }

    public void ShowExplosion() {
        GameObject go = Instantiate(this.shellExplosion, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(go, 1.5f);
        Destroy(this.gameObject);
    }
}
