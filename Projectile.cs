using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    int damage = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * speed * Time.deltaTime;
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;
            if (!SoundClips.instance._audio.isPlaying)
            {
                SoundClips.instance._audio.clip = SoundClips.instance._clips[5];
                SoundClips.instance._audio.Play();
            }
            else
            {
                SoundClips.instance._audio.Stop();
                SoundClips.instance._audio.clip = SoundClips.instance._clips[5];
                SoundClips.instance._audio.Play();
            }
            Destroy(this.gameObject);
        }
    }
}
