using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;





public class GameController : MonoBehaviour {
    private static GameController instance;
	private AsyncOperation asyncOperation; 
    

    public const string SCENE_TANK_CHOOSE = "TankChoose", 
        SCENE_SOLO = "SOLO", 
        SCENE_SINGLEPLAYER = "SinglePlayer", 
        SCENE_MULTIPLAYER = "MultiPlayer";

	public bool isPlaying=true;
	private GameObject mainCamera;
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }
	// Use this for initialization
	void Awake () {
        instance = this;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Main") {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESCAPE");
            }
        }
	}

	public void StartGame(string gameMode){
		switch (gameMode) {
		case SCENE_SOLO:
			GameObject go1 = ResourcesManager.Instance.GetGameObject ("Tank1"); 
			GameObject go2 = ResourcesManager.Instance.GetGameObject ("Tank2");
			mainCamera = ResourcesManager.Instance.GetGameObject ("SOLOCamera");
			GameObject env = ResourcesManager.Instance.GetGameObject ("SOLOEnviroments");
			go1.GetComponent<TankController> ().playID = 1;
			go2.GetComponent<TankController> ().playID = 2;
			GameObject.Instantiate (go1);
			GameObject.Instantiate (go2);
			GameObject.Instantiate (mainCamera);
			GameObject.Instantiate (env);
			break;
		case SCENE_MULTIPLAYER:
			break;
		case SCENE_SINGLEPLAYER:
			break;
		default:
			break;
		}
	}
	void OnGUI(){
		if (this.asyncOperation != null && !this.asyncOperation.isDone) {
			GUILayout.Label ("进度:"+this.asyncOperation.progress*100+"%");
		}
	}


	public void StartScene(string scenename){
		StartCoroutine(LoadScene(scenename));	
	}
	private IEnumerator LoadScene(string scenename) {
		Debug.Log ("loadScene");
		asyncOperation= SceneManager.LoadSceneAsync(scenename);
		SceneManager.MoveGameObjectToScene(this.gameObject,SceneManager.GetSceneByName("SOLO"));
		yield return asyncOperation;
		GameController.Instance.StartGame (SCENE_SOLO);
        this.asyncOperation = null;
    }
}
