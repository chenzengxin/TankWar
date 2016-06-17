using UnityEngine;
using System.Collections;

public class PropeManager : MonoBehaviour {

    private static PropeManager instance;
    private GameObject[] props;
    private bool flag;

    public static PropeManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(PropeManager)) as PropeManager;
                if (!instance)
                {
                    GameObject go = new GameObject("PropeManager");
                    instance = go.AddComponent<PropeManager>();
                }
            }
            return instance;
        }
    }

    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void Begin() {
        this.flag = true;
        StartCoroutine(ShowProp());

    }
    public PropeManager Init(params GameObject[] props) {
        this.props = props;
        return instance;
    }
    public void Stop() {
        this.flag = false;
    }
    public PropeManager Init() {
        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = Vector3.one * 100;
        //cube1.AddComponent<Cube>();
        cube1.GetComponent<BoxCollider>().isTrigger = true;
        cube1.AddComponent<InfluenceBig>();
        cube1.AddComponent<CubeController>();

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = Vector3.one * 100;
        //cube1.AddComponent<Cube>();
        cube2.GetComponent<BoxCollider>().isTrigger = true;
        cube2.AddComponent<InfluenceSpeedy>();
        cube2.AddComponent<CubeController>();

        GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3.transform.position = Vector3.one * 100;
        //cube1.AddComponent<Cube>();
        cube3.GetComponent<BoxCollider>().isTrigger = true;
        cube3.AddComponent<InfluenceHeal>();
        cube3.AddComponent<CubeController>();


        this.props = new GameObject[] { cube1,cube2,cube3};

        return instance;
    }
    private IEnumerator ShowProp() {
        while (flag) {
            GameObject go=Instantiate(props[Random.Range(0,props.Length)],new Vector3(Random.Range(-40,10),.5f,Random.Range(-8,4)),Quaternion.identity) as GameObject;
            Destroy(go,10);
            yield return new WaitForSeconds(30);
        }
    }
}
