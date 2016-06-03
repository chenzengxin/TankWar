using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour
{
	private new Rigidbody rigidbody;
    private Vector3 direction;
    private float speed = 10;
    private float angularspeed = 5;





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
    public float Angularspeed
    {
        get
        {
            return angularspeed;
        }

        set
        {
            angularspeed = value;
        }
    } 

    // Use this for initialization
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float x, float y)
    {
        direction = this.transform.forward * y;
        this.rigidbody.velocity = ((direction) * this.Speed);
        direction = Vector3.zero;
        if (y == 0)//防止单独按左右无反应
            y = 1;
        this.rigidbody.angularVelocity = transform.up * this.Angularspeed*x*y;
    }
}
