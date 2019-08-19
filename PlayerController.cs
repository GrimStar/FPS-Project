using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    Animator anim;
    [SerializeField]
    float speed = 2f;
    float speedMulti = 2f;
    Rigidbody rb;
    [SerializeField]
    public bool grounded = true;
    [SerializeField]
    bool jumping = false;
    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    float groundCheckDistance = 0.25f;
    [SerializeField]
    float maxGroundedDistance = 0.05f;
    [SerializeField]
    Transform feet;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float xAxis = Input.GetAxis("Horizontal");
        rb.AddForce(transform.right * (speed * speedMulti * xAxis));
        
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().clip = SoundClips.instance._clips[6];
                }
                else
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().clip = SoundClips.instance._clips[6];
                }
                GetComponent<AudioSource>().Play();
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                GetComponent<PlayerAnimControl>().anim.SetTrigger("jump");
            }
        }
        CheckIfGrounded();
    }
    void CheckIfGrounded()
    {
        RaycastHit hit;
        if(Physics.Raycast(feet.position, -transform.up, out hit, groundCheckDistance))
        {
            if(Vector3.Distance(feet.position, hit.point) > maxGroundedDistance)
            {
                grounded = false;
            }
            else
            {
                if (!grounded)
                {
                    if (!GetComponent<AudioSource>().isPlaying)
                    {
                        GetComponent<AudioSource>().clip = SoundClips.instance._clips[7];
                    }
                    else
                    {
                        GetComponent<AudioSource>().Stop();
                    }
                    GetComponent<AudioSource>().Play();
                }
                grounded = true;
            }


        }
        else
        {
            grounded = false;
        }
    }
}
