using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 1;

    public float destroyTime = 10.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;

        if(destroyTime <= 0)
            Destroy(gameObject);
    }

}
