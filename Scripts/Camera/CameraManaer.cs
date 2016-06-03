using UnityEngine;
using System.Collections;

public class CameraManaer : MonoBehaviour
{
    private GameObject[] targets;
    private Vector3 dir;
    private new Camera camera;
    // Use this for initialization
    void Start()
    {
		this.Init ();
    }
	void Init(){
		targets = GameObject.FindGameObjectsWithTag("Player");
		//Debug.Log(targets[1]);
		camera = GetComponent<Camera>();
		dir = this.transform.position - (targets[1].transform.position + targets[0].transform.position) / 2;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        if (GameController.Instance.isPlaying)
        {
            this.transform.position = dir + (targets[1].transform.position + targets[0].transform.position) / 2;
            camera.orthographicSize = Vector3.Distance(targets[1].transform.position,targets[0].transform.position);
        }
    }
}
