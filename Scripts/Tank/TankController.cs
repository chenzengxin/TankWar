using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour
{
    private TankMovement tankMove;
    private TankAttack tankAttack;
    public KeyCode fireKey=KeyCode.Space;
    

    public int playID;
    // Use this for initialization
    void Awake()
    {
        tankMove = GetComponent<TankMovement>();
        tankAttack = GetComponent<TankAttack>();
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"+"Player"+ playID);
        float y = Input.GetAxis("Vertical" + "Player" + playID);
        if (x != 0 || y != 0)
        {
            this.tankMove.Move(x, y);
        }
        if (Input.GetKeyDown(fireKey))
        {
            tankAttack.Fire();
        }
    }
}
