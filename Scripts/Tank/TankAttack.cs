using UnityEngine;
using System.Collections;






public class TankAttack : MonoBehaviour {
    private Transform firePosition;
    public GameObject shellPrefabBig;
    public GameObject shellPrefabNormal;
    private GameObject attackShell;
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
    public void Fire() {
        GameObject go=GameObject.Instantiate(shellPrefabNormal, firePosition.position, firePosition.rotation) as GameObject;
        go.transform.parent = this.gameObject.transform;
    }
}
