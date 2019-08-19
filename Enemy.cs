using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    int damage = 20;
    [SerializeField]
    public int health = 100;
    bool attacking = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(Timer());
                other.gameObject.GetComponent<Player>().Health -= damage;
            }
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }
}
