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
		Init ();
    }
	public void Init(){
		tankMove = GetComponent<TankMovement>();
		tankAttack = GetComponent<TankAttack>();
	}
    // Update is called once per frame
    public void FixedUpdate()
    {
		if (GameController.Instance.isPlaying) {
			float x = Input.GetAxis ("HorizontalPlayer" + playID);
			float y = Input.GetAxis ("VerticalPlayer" + playID);
			if (x != 0 || y != 0) {
				this.tankMove.Move (x, y);
			}
		}
    }
    public void Update() {
		if (Input.GetKeyDown(fireKey)&&GameController.Instance.isPlaying)
        {
            tankAttack.Fire();
        }
    }
    public void SetBigShell() {
        this.tankAttack.SetBigShell();
    }
}
