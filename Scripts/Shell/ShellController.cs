using UnityEngine;
using System.Collections;



public class ShellController : MonoBehaviour {
    private float speed=20;
	private new Rigidbody rigidbody;
    public GameObject shellExplosion;
    public float damage;
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


    public void OnTriggerEnter(Collider collider) {
        ShowExplosion();
        if (collider.tag == "Player")
        {
            collider.SendMessage("TakeDamage",damage);
        }
        Debug.Log(collider.tag);
    }

    public void ShowExplosion() {
        GameObject go = Instantiate(this.shellExplosion, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(go, 1.5f);
        Destroy(this.gameObject);
    }
}
