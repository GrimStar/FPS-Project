using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroScene : MonoBehaviour {

    [SerializeField]
    GameObject gg;
    [SerializeField]
    GameObject fs;
    [SerializeField]
    GameObject pa;
    [SerializeField]
    float moveAmount = 20f;
    Vector3 startPosition;
    Vector3 targetPosition;
    [SerializeField]
    float interval = 3f;
    bool waiting = false;
    GameObject removeable;
    List<GameObject> logos = new List<GameObject>();
    int count = 0;
    [SerializeField]
    float speed = 2f;
    Vector3 removePosition;
    [SerializeField]
    AudioSource _audioOne;
    [SerializeField]
    AudioSource _audioTwo;
    
    bool soundOneIsPlaying = false;
    bool soundTwoIsPlaying = false;
    [SerializeField]
    float soundDelay = 1f;
    [SerializeField]
    float cutSceneDelay = 2f;
	// Use this for initialization
	void Start () {
        StartCoroutine(SoundPlayDelay());
        logos.Add(fs);
        logos.Add(pa);
        logos.Add(gg);
        startPosition = fs.transform.position;
        targetPosition = new Vector3(fs.transform.position.x - moveAmount, fs.transform.position.y, fs.transform.position.z);
        removePosition = new Vector3(targetPosition.x - moveAmount, fs.transform.position.y, fs.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if(logos[count].transform.position.x <= targetPosition.x + 2f)
        {
            
            if (!waiting)
            {
                Debug.Log("HitTarget");
                removeable = logos[count];
                
                StartCoroutine(IntervalTimer());
                waiting = true;
            }
        }
        logos[count].transform.position = Vector3.Lerp(logos[count].transform.position, targetPosition, speed * Time.deltaTime);
        if (!waiting)
        {
            if(removeable != null)
            {
                
                removeable.transform.position = Vector3.Lerp(removeable.transform.position, removePosition, speed * Time.deltaTime);
            }
        }
		
	}
    IEnumerator IntervalTimer()
    {
        if (count == 2)
        {
            StartCoroutine(CutScene());
            _audioTwo.Play();
        }
        
        yield return new WaitForSeconds(interval);
        if(count < 1)
        {
            StartCoroutine(SoundPlayDelay());
        }
        if(count != 2)
        {
            count++;
            
            waiting = false;
        }
        
    }
    IEnumerator CutScene()
    {
        yield return new WaitForSeconds(cutSceneDelay);
        SceneManager.LoadScene("MainMenu");
        Destroy(this);
    }
    IEnumerator SoundPlayDelay()
    {
        yield return new WaitForSeconds(soundDelay);
        
        _audioOne.Play();

    }
}
