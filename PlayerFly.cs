using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {

    [SerializeField]
    float flyForce = 10f;
    PlayerInventory playerInv;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        playerInv = GetComponent<PlayerInventory>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.W)){
            if(playerInv.angelDust > 0)
            {
                rb.AddForce(transform.up * flyForce);
                playerInv.angelDust -= Time.deltaTime;
            }
        }
	}
}
