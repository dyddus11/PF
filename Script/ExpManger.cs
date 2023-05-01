using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManger : MonoBehaviour
{
    private int Lv = 1; 

    private float Exp = 0; 
    private float expToLevelUp = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal void GainExp(float amount)
    {
        Exp += amount;

        if(Exp >= expToLevelUp)
            LevelUp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelUp()
    {
        Lv++; 

        Exp = 0;

        expToLevelUp = Mathf.RoundToInt(expToLevelUp * 1.5f); 

        Debug.Log("Level Up!");

    }
}
