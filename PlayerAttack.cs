using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    bool right = true;
    PlayerInventory inv;
    bool shooting = false;
    [SerializeField]
    float cooldown = 0.5f;
    AudioSource _audio;
	// Use this for initialization
	void Start () {
        inv = GetComponent<PlayerInventory>();
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0)
        {
            right = true;
            
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (inv.ammo > 0)
            {
                if (!shooting)
                {
                    inv.ammo--;
                    shooting = true;
                    StartCoroutine(ShotCooldown());
                }
            }
        }
	}
    void Shoot()
    {
        GameObject _projectile = Instantiate(prefab);
        if (_audio.isPlaying)
        {
            _audio.Stop();
        }
        _audio.clip = SoundClips.instance._clips[2];
        _audio.Play();
        if (!right)
        {
            _projectile.transform.position = transform.position + -transform.right;
            _projectile.transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
        else
        {
            _projectile.transform.position = transform.position + transform.right;
            _projectile.transform.rotation = Quaternion.identity;
        }
    }
    IEnumerator ShotCooldown()
    {
        Shoot();
        yield return new WaitForSeconds(cooldown);
        shooting = false;
    }
}
