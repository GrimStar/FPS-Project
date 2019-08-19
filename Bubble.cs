using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    [SerializeField]
    float timerMax = 10f;
    [SerializeField]
    float startDelay = 2f;
    bool isActive = false;
    bool countingDown = false;
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    GameObject bubble;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(StartDelay());
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isActive)
        {
            if (bubble.transform.localScale.y < 1f)
            {
                Vector3 scaleInc = new Vector3(0.1f, 0.1f, 0.1f);
                bubble.transform.localScale += scaleInc * speed * Time.deltaTime;
            }
            else
            {
                if (bubble.transform.gameObject.activeSelf)
                {
                    bubble.transform.localScale = Vector3.zero;
                    bubble.SetActive(false);
                    
                    if (!countingDown)
                    {
                        StartCoroutine(CountDown());
                        countingDown = true;
                        isActive = false;
                    }
                    
                }
            }
        }
	}
    void StartBubble()
    {
        Debug.Log("StartBubble");
        bubble.SetActive(true);
        isActive = true;
    }
    IEnumerator CountDown()
    {
        Debug.Log("countdown");
        float delay = Random.Range(3f, timerMax);
        yield return new WaitForSeconds(delay);
        StartBubble();
        countingDown = false;
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartBubble();
    }
}
