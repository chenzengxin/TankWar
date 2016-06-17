using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour
{
    public TankMovement tankMove;
    public TankAttack tankAttack;
    public KeyCode fireKey=KeyCode.Space;
    public int playID;
    public AudioClip idleClip;
    public AudioClip drivingClip;
    public AudioSource audioSource;


    // Use this for initialization
    void Awake()
    {
    }
	public void Init(int playID,KeyCode fireKey){
		tankMove = this.GetComponent<TankMovement>();
		tankAttack = this.GetComponent<TankAttack>();
        idleClip = Resources.Load<AudioClip>("AudioClips\\EngineIdle");
        drivingClip = Resources.Load<AudioClip>("AudioClips\\EngineDriving");
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = idleClip;
        audioSource.loop = true;
        this.playID = playID;
        this.fireKey = fireKey;
	}
    // Update is called once per frame
    public void FixedUpdate()
    {
		float x = Input.GetAxis ("HorizontalPlayer" + playID);
		float y = Input.GetAxis ("VerticalPlayer" + playID);
        if (x != 0 || y != 0)
        {
            this.tankMove.Move(x, y);
            this.audioSource.clip = this.drivingClip;
        }
        else
        {
            this.audioSource.clip = this.idleClip;
        }
        if (audioSource.isPlaying == false)
        {
            this.audioSource.Play();
        }

    }
    public void GetLose() {
        PlayerPrefs.SetInt("Player"+(playID==1?2:1), PlayerPrefs.GetInt("Player" + (playID == 1 ? 2 : 1))+1);
    }
    public void Update() {
		if (Input.GetKeyDown(fireKey))
        {
            tankAttack.Fire();
        }
    }

    public void SetBigModel() {
        this.SetBigShell();
        StopAllCoroutines();
        StartCoroutine(ChangeTankSize(2));
        Invoke("SetNormal",15);
    }

    private void SetNormal() {
        this.SetNormalShell();
        StartCoroutine(ChangeTankSize(1));
    }

    public void SetSpeedy() {
        StopAllCoroutines();
        this.tankMove.Speed *= 1.5f;
        this.tankAttack.FileSpeed *= 1.5f;
        Invoke("SetNormalSpeed", 15);
    }

    private void SetNormalSpeed() {
        this.tankMove.Speed /= 1.5f;
        this.tankAttack.FileSpeed /= 1.5f;
    }

    private IEnumerator ChangeTankSize(int size){
        while (System.Math.Abs(transform.localScale.x - size) > .01)
        {
            this.transform.localScale = Vector3.Slerp(this.transform.localScale, Vector3.one * size, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
    }








    private void SetBigShell() {
        this.tankAttack.SetBigShell();
    }

    private void SetNormalShell() {
        this.tankAttack.SetNormalShell();
    }
}
