using UnityEngine;
using System.Collections;

public class TankData : MonoBehaviour {
    private int hp=100;

    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }



    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    public void TakeDamage(int damage=0) {
        if (hp < 0)
            return;
        else
        {
            if(damage==0)
                this.hp -= Random.Range(10,20);
        }
    }
}
