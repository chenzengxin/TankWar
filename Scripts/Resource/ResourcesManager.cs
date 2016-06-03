using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {
	private Hashtable table=new Hashtable();
    private static ResourcesManager instance;

    public static ResourcesManager Instance
    {
        get
        {
            return instance;
        }
    }
    // Use this for initialization
    void Awake () {
        if (instance!=this)
            instance = this;
    }
	// Update is called once per frame
	void Update () {

	}
    public GameObject GetGameObject(string name) {
        GameObject go=Resources.Load<GameObject>("Prefabs/"+name);
        //Debug.Log(go);
        return go;
    }


}
