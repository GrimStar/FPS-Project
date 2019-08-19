using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

    [SerializeField]
    GameObject EndBackground;
    public static LevelControl instance;
    [SerializeField]
    GameObject gameOverScreen;
    [SerializeField]
    GameObject endOfLevelScreen;
    [SerializeField]
    Component[] toDisable;
    public bool gameOver = false;
    public bool endOfLevel = false;
    GameObject player;
    [SerializeField]
    GameObject angelPlayer;
    [SerializeField]
    GameObject playerModel;
    [SerializeField]
    GameObject angels;
    bool riseToHeaven = false;
    [SerializeField]
    float endDelay = 2f;
    [SerializeField]
    float riseSpeed = 2f;
    bool waiting = false;
    [SerializeField]
    Camera cam;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (riseToHeaven)
        {
            RiseToHeaven();
        }
	}
    public void EndOfLevel()
    {
        cam.transform.parent = null;
        endOfLevel = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerFly>().enabled = false;
        playerModel.SetActive(false);
        angelPlayer.SetActive(true);
        EndBackground.SetActive(true);
        if (!waiting)
        {
            waiting = true;
            StartCoroutine(EndDelay());
        }
        
    }
    public void GameOver()
    {
        gameOver = true;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerController>().enabled = false;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    void RiseToHeaven()
    {
        //player.transform.position += transform.up * riseSpeed * Time.deltaTime;

    }
    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(endDelay);
        endOfLevelScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
