using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ButtonController : MonoBehaviour,IPointerEnterHandler{
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource=this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void NewGame() {
		GameController.Instance.StartScene (GameController.SCENE_SOLO);
    }

    public void LoadGame() {
        Debug.Log("loadgame");
    }
    public void PlayAudio() {
        this.audioSource.Play();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayAudio();
    }
}
