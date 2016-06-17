using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    private static GameController instance;
	private AsyncOperation asyncOperation;
    public const string SCENE_TANK_CHOOSE = "TankChoose", 
        SCENE_SINGLEPLAYER = "SinglePlayer", 
        SCENE_MULTIPLAYER = "MultiPlayer",
        SCENE_STARTSCENE="StartScene";

	public bool isPlaying=true;

    void Awake() {
       
    }
    public static GameController Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(GameController)) as GameController;
                if (!instance)
                {
                    GameObject go = new GameObject("GameController");
                    instance=go.AddComponent<GameController>();
                    DontDestroyOnLoad(instance);                   
                }
            }
            return instance;
        }
    }
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != SCENE_STARTSCENE) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESCAPE");
                UIManager.Instance.ShowPanel();

            }
        }
	}

	public void StartGame(string gameMode){
		switch (gameMode) {
		case SCENE_MULTIPLAYER:
            
            GameObject go1 = ResourcesManager.Instance.GetGameObject ("Tank1"); 
			GameObject go2 = ResourcesManager.Instance.GetGameObject ("Tank2");
			GameObject mainCamera = ResourcesManager.Instance.GetGameObject ("SOLOCamera");

			GameObject env = ResourcesManager.Instance.GetGameObject ("SOLOEnviroments");
			TankController player1=go1.GetComponent<TankController>();
            player1.Init(1,KeyCode.Space);
            TankController player2=go2.GetComponent<TankController>();
            player2.Init(2,KeyCode.KeypadEnter);
			GameObject.Instantiate (go1);
			GameObject.Instantiate (go2);
			GameObject.Instantiate (mainCamera);
			GameObject.Instantiate (env);
            mainCamera.GetComponent<CameraManaer>().Init();
            GameObject c1 = ResourcesManager.Instance.GetGameObject("Cube");
            c1.AddComponent<InfluenceBig>();
            GameObject c2 = ResourcesManager.Instance.GetGameObject("Cube");
            c2.AddComponent<InfluenceSpeedy>();
            PropeManager.Instance.Init().Begin();
            //UIManager.Instance.InstantiateUI("我只是测试下行不行");
			break;
		case SCENE_SINGLEPLAYER:
            Debug.Log("未完待续");
			break;
		default:
			break;
		}
        GameController.Instance.isPlaying = true;
    }
	void OnGUI(){
		if (this.asyncOperation != null && !this.asyncOperation.isDone) {
			GUILayout.Label ("加载场景进度:"+this.asyncOperation.progress*100+"%");
		}
	}
	public void StartScene(string scenename){
		StartCoroutine(LoadScene(scenename));	
	}
	private IEnumerator LoadScene(string scenename) {
		//Debug.Log ("loadScene");
		asyncOperation= SceneManager.LoadSceneAsync(scenename);
		yield return asyncOperation;
		GameController.Instance.StartGame (scenename);
        this.asyncOperation = null;
    }
}
