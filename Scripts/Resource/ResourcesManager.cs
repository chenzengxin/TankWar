using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {
	private Hashtable table=new Hashtable();
    private static ResourcesManager instance;

    public static ResourcesManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(ResourcesManager)) as ResourcesManager;
                if (!instance)
                {
                    GameObject go = new GameObject("ResourcesManager");
                    instance=go.AddComponent<ResourcesManager>();
                    DontDestroyOnLoad(instance);
                }
            }
            return instance;
        }
    }
    public GameObject GetGameObject(string name) {
        GameObject go=Resources.Load<GameObject>("Prefabs/"+name);
        return go;
    }


}
