using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManger : MonoBehaviour
{
    public class Body 
    {
        public Vector3 position;
        public Quaternion rotation; 

        public Body(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    public List<Snake> bodyList = new List<Snake>();

    void Start()
    {
        
    }

    void FixedUpdate() 
    {
        UpdateBodyList();    
    }

    public void UpdateBodyList()
    {

    }

    public void ClearBodyList()
    {
        
    }

    void Update()
    {
        
    }
}
