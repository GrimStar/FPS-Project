using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconControl : MonoBehaviour {

    [SerializeField]
    Sprite[] icons;
    float amount = 0f;
    [SerializeField]
    bool holyBalls = true;
    [SerializeField]
    bool angelDust = false;
    [SerializeField]
    Text _amountText;
	// Use this for initialization
	void Start () {

        transform.GetComponent<Image>().sprite = icons[0];
        
	}
	
	// Update is called once per frame
	void Update () {

        if (holyBalls)
        {
            amount = PlayerInventory.instance.ammo;
            if(amount <= 0)
            {
                if (GetComponent<Image>().sprite != icons[0])
                {
                    GetComponent<Image>().sprite = icons[0];
                }
                
            }
            else
            {
                if (GetComponent<Image>().sprite != icons[1])
                {
                    GetComponent<Image>().sprite = icons[1];
                }

            }
        }
        else
        {
            amount = PlayerInventory.instance.angelDust;
            if (amount <= 0)
            {
                if (GetComponent<Image>().sprite != icons[0])
                {
                    GetComponent<Image>().sprite = icons[0];
                }
            }
            else
            {
                if (GetComponent<Image>().sprite != icons[1])
                {
                    GetComponent<Image>().sprite = icons[1];
                }

            }
        }
        _amountText.text = amount.ToString();
	}
}
