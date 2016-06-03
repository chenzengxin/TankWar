using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Test : MonoBehaviour {
	private bool flag = false;

	void Awake(){
		Debug.Log ("On Awake");
	}
	void OnEnable(){
		Debug.LogError ("On Enable");
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("On Start");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("On Update");
	}
	void LateUpdate(){
		Debug.LogError ("On LaterUpdate");
		if (!flag) {
			DontDestroyOnLoad (this);
			SceneManager.LoadSceneAsync (0);
			flag = true;
		}
	}
	void FixedUpdate(){
		Debug.Log ("On FixedUpdate");
	}


	IEnumerator ShowInfo(){
		Debug.Log (Time.time);
		yield return new WaitForSeconds (1);
	}
}
