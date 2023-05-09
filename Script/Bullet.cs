using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 1f;
    public float speed;

    public float destroyTime = 10.0f;

    BulletController _bulletController;

    void Start()
    {
        
        setSpeed(this.speed);
    }

    public void setSpeed(float speed)
    {
        BulletController bulletController = GetComponent<BulletController>();
        bulletController.setSpeed(speed);
    }

    public void setStop()
    {
        BulletController bulletController = GetComponent<BulletController>();
        bulletController.stop = !bulletController.stop;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;

        if(destroyTime <= 0)
            Destroy(gameObject);
    }

    

}
