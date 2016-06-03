using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void NewGame() {
        GameController.Instance.LoadScene("Main");
    }

    public void LoadGame() {

    }
    public void ShowSettings() {
        
    }
}
