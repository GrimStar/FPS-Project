using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {

    [SerializeField]
    float bounce = 20f;
    GameObject player;
    bool contact = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (contact)
        {
           // player.transform.GetComponent<Rigidbody>().AddForce(player.transform.up * bounce, ForceMode.Impulse);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            contact = true;
            player.transform.GetComponent<Rigidbody>().AddForce(player.transform.up * bounce, ForceMode.Impulse);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            contact = false;

        }
    }
}
