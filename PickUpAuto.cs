using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAuto : MonoBehaviour {

    [SerializeField]
    bool dust = true;
    [SerializeField]
    bool ammo = false;
    [SerializeField]
    int amount = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (dust)
            {
                other.gameObject.GetComponent<PlayerInventory>().angelDust += amount;
            }
            if (ammo)
            {
                other.gameObject.GetComponent<PlayerInventory>().ammo += amount;
            }
            AudioSource _audio = other.gameObject.GetComponent<AudioSource>();
            if (!_audio.isPlaying)
            {
                _audio.clip = SoundClips.instance._clips[3];
                _audio.Play();
            }
            Destroy(this.gameObject);
        }
    }
}
