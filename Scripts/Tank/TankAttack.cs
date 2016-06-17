using UnityEngine;
using System.Collections;






public class TankAttack : MonoBehaviour {
    private Transform firePosition;
    public GameObject shellPrefabBig;
    public GameObject shellPrefabNormal;
    private GameObject attackShell;
    private float fileSpeed=20;

    public float FileSpeed
    {
        get
        {
            return fileSpeed;
        }

        set
        {
            fileSpeed = value;
        }
    }

    void Awake () {
        firePosition = this.gameObject.transform.Find("FirePosition");
        shellPrefabNormal = Resources.Load<GameObject>("Prefabs/NormalShell");
        shellPrefabBig = Resources.Load<GameObject>("Prefabs/BigShell");
        //this.SetBigShell(2);
        this.attackShell = this.shellPrefabNormal;
	}
	void Update () {
	    
	}
    public void SetBigShell() {
        this.attackShell = shellPrefabBig;
    }
    public void SetNormalShell() {
        this.attackShell = shellPrefabNormal;
    }
    public void Fire() {
        GameObject go=GameObject.Instantiate(attackShell, firePosition.position, firePosition.rotation) as GameObject;
        go.transform.parent = this.gameObject.transform;
        go.GetComponent<ShellController>().Speed = fileSpeed;
    }
}
