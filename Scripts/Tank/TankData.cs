using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TankData : MonoBehaviour {
    private float hp=100;
    private float maxHP = 100;
    private Slider hpBar;
    private TankController tc;
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
        this.hpBar = this.gameObject.GetComponentInChildren<Slider>();
        this.tc = GetComponent<TankController>();
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
            UpdateHPBar();
            Debug.Log(this.hp);
            if (hp <= 0)
            {
                GameObject go=GameObject.Instantiate(ResourcesManager.Instance.GetGameObject("TankExplosion"),this.transform.position,this.transform.rotation) as GameObject;
				GameController.Instance.isPlaying = false;
                this.tc.GetLose();
                UIManager.Instance.ShowPanel();
                Destroy(go,3);
				Destroy(this.gameObject);
            }
        }
    }

    public void GetHeal(int value) {
        this.hp += value;
        if (hp > maxHP)
            hp = maxHP;
        UpdateHPBar();
    }

    public void UpdateHPBar() {
        hpBar.value = this.hp / this.maxHP;
    }
}
