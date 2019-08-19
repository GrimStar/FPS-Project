using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePit : MonoBehaviour {

    AudioSource _audio;
    [SerializeField]
    float speed = 5f;
    GameObject player;
  
    bool gameOver = false;
    [SerializeField]
    float maxDist = 16f;
    [SerializeField]
    float minDist = 0f;
	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(_audio.clip == null)
        {
            
            _audio.clip = SoundClips.instance._clips[0];
        }
        if (!LevelControl.instance.gameOver && !LevelControl.instance.endOfLevel)
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();

            }
            transform.position += transform.up * speed * Time.deltaTime;
            float playerDist = player.transform.position.y - transform.position.y - 7f;
            float perc = Mathf.InverseLerp(minDist, maxDist, playerDist);
            _audio.volume = perc;
            // Debug.Log(playerDist.ToString() + " " + perc.ToString());
            //_audio.volume = perc;
        }
        if(LevelControl.instance.gameOver)
        {
            if(_audio.isPlaying)
            {
                _audio.Stop();
            }
        }
	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {

            player.transform.GetComponent<Player>().Health -= 9999;
            if (!player.GetComponent<AudioSource>().isPlaying)
            {
                player.GetComponent<AudioSource>().clip = SoundClips.instance._clips[4];
            }
            else
            {
                player.GetComponent<AudioSource>().Stop();
                player.GetComponent<AudioSource>().clip = SoundClips.instance._clips[4];
                
            }
            player.GetComponent<AudioSource>().Play();

            LevelControl.instance.GameOver();

           
        }
    }
    
}
