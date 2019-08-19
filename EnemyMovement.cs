using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;
    float ratio = 0f;
    [SerializeField]
    float speed = 2f;
    float targetRatio = 0f;
    float targetRatioV;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ratio <= 0.1f)
        {
            targetRatio = 1f;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(ratio >= 0.9f)
        {
            targetRatio = 0f;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        ratio = Mathf.SmoothDamp(ratio, targetRatio, ref targetRatioV, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, ratio);
	}
}
