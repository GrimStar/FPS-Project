using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 5;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            HealthBar.instance.UpdateHealthBar(value);
            CheckHealth();
        }
    }
    bool dead = false;
	
	
    void CheckHealth()
    {
        if (Health <= 0)
        {
            if (!dead)
            {
                dead = true;
                LevelControl.instance.GameOver();

            }
        }
    }
}
