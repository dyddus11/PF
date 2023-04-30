using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float _distance;
    public GameObject Player; 

    public float ATK = 1f;
    public float coolTime = 3f;

    public float Hp  = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void moving()
    {
        Transform playerPos = Player.transform;

        Vector3 dir = playerPos.position - transform.position; 

        _distance = dir.magnitude;

        if(_distance > 0.9f)
        {   
            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        }

    }

    void attack()
    {
       Player.GetComponent<Snake>()._hp -= ATK;
    }

    void takeDamage(float damage)
    {
        Hp -= damage;
    }

    void dead()
    {
        Destroy(gameObject);
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moving();

        if(_distance <= 1.0f)
        {   
            coolTime -= Time.deltaTime;

            if(coolTime <= 0)
            {
                attack();    
                coolTime = 3f;
            }
        }

        if(Hp <= 0)
        {
            dead();
        }
    }
}
