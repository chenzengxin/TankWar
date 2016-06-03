using UnityEngine;
using System.Collections;

public class TankData : MonoBehaviour {
    private float hp=100;

    public float HP
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


    public void TakeDamage(float damage) {
        if (hp < 0)
            return;
        else
        {
            this.hp -= damage;
            if (hp <= 0)
            {
                GameObject go=GameObject.Instantiate(ResourcesManager.Instance.GetGameObject("TankExplosion"),this.transform.position,this.transform.rotation) as GameObject;
				GameController.Instance.isPlaying = false;
                Destroy(go,3);
				Destroy(this.gameObject);

            }
        }
    }
}
