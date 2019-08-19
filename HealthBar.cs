using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public static HealthBar instance;
    [SerializeField]
    GameObject[] healthIcons;
	// Use this for initialization
	void Start () {
		if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateHealthBar(int _health)
    {
        int count = _health;       
        foreach(GameObject _icon in healthIcons)
        {
            if(count > 0)
            {
                _icon.SetActive(true);
            }
            else
            {
                _icon.SetActive(false);
            }
            count--;
        }
    }
}
