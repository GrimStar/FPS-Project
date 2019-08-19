using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour {
    [SerializeField]
    GameObject player;
    public Animator anim;
    Rigidbody rb;
    PlayerController _controller;
    
	// Use this for initialization
	void Start () {
        anim = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _controller = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 6f);
        if(Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walking", true);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walking", true);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walking", false);
            anim.SetBool("idle", true);
            
        }
        if(rb.velocity.y < 0)
        {
            anim.SetFloat("yVelocity", -1f);
        }
        else
        {
            anim.SetFloat("yVelocity", 1f);
        }
        if (_controller.grounded)
        {
            anim.SetBool("grounded", true);
            
            
        }
        else
        {
            anim.SetBool("grounded", false);
        }

	}
}
