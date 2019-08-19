using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public static PlayerInventory instance;
    [SerializeField]
    public float angelDust = 0f;
    [SerializeField]
    public float ammo = 0f;

    private void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
