using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    private static UIManager instance;

    public const string UINAME_HPBAR = "HP_Bar", UINAME_INFORMATION = "Information";

    private GameObject panel;
    private Text[] infoTexts;
    public static UIManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(UIManager)) as UIManager;
                if (!instance)
                {
                    GameObject go = new GameObject("UIManager");
                    instance = go.AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }

    void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        panel = Instantiate(Resources.Load("Prefabs\\Panel")) as GameObject;
        panel.transform.parent = this.gameObject.transform;
        panel.transform.localPosition = Vector3.zero;
        panel.SetActive(false);
        infoTexts = panel.GetComponentsInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowPanel() {
        panel.SetActive(!panel.activeSelf);
        if (!panel.activeSelf)
            return;
        for (int i = 0; i < 2; i++)
        {
            infoTexts[i].text = "Player" + (i + 1).ToString() + ":" + PlayerPrefs.GetInt("Player"+(i+1), 0);
        }
    }
    public GameObject InstantiateUI(string uiName) {
        GameObject go = new GameObject(uiName);
        go.layer = this.gameObject.layer;
        RectTransform t=go.AddComponent<RectTransform>();
        t.SetParent(this.transform);
        return go;
    }
}
