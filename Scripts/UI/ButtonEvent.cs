using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour,IPointerEnterHandler{
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource=this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void NewGame() {
		//GameController.Instance.StartScene (GameController.SCENE_SOLO);
        GameObject sbtn = this.transform.FindChild("SinglePlayer").gameObject;
        GameObject mbtn = this.transform.FindChild("MultiPlayer").gameObject;
        sbtn.SetActive(true);
        mbtn.SetActive(true);
        this.transform.FindChild("NewGame").gameObject.SetActive(false);
        this.transform.FindChild("LoadGame").gameObject.SetActive(false);
    }

    public void LoadGame() {
        Debug.Log("loadgame");
    }
    public void PlayAudio() {
        if(audioSource!=null)
            this.audioSource.Play();
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void SingleGame() {
        GameController.Instance.StartScene(GameController.SCENE_SINGLEPLAYER);
    }
    public void MultiPlayer() {
        GameController.Instance.StartScene(GameController.SCENE_MULTIPLAYER);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayAudio();
    }
    public void RestartGame() {
        
        GameController.Instance.StartScene(GameController.SCENE_MULTIPLAYER);
    }

}
