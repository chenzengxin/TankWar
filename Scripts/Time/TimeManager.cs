using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    private int s = 0;
    private int m = 0;
    private int h = 0;
    // Use this for initialization
    void Start() {
        StartCoroutine(TimeTick());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator TimeTick() {
        while (true) {
            yield return new WaitForSeconds(1);
            s++;
            if (h >= 24)
            {
                h = 0;
            }
            if (m >= 60)
            {
                m = 0;
                h++;
            }
            if (s >= 60)
            {
                s = 0;
                m++;
            }
            
        }
    }

    void OnGUI(){
        GUILayout.Label((h<10?"0"+h:h.ToString())+":"+(m<10?"0"+m:m.ToString())+":"+(s<10?"0"+s:s.ToString()));
    }
}
