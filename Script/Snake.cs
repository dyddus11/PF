using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float _moveSpeed = 1000f;

    public float _hp = 100f;

    public float currentHp;

    public float coolTime = 1f;

    public Transform firePoint;

    public bool isEnemyDetected = false;

    public float detectionRadius = 1f; 

    private List<Enemy> enemies;

    public GameObject bulletPrefab;
    public float turnSpeed = 180f;

    public HpBar healthBar;


    float countUp = 0.2f;

    public void findEnemy()
    {
        Enemy nearestEnemy = null; 
        float nearestDistance = Mathf.Infinity;
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>()); 

        foreach(Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if(distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        if(nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();

            Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;

            bulletController.SetDirection(direction);

            bulletController.SetEnemyPosition(nearestEnemy.GetPos());
        }
    }

    public void TakeDamge(float damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = _hp;
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>()); 
        healthBar.setMaxHealth(_hp);
    }
 
    void attack()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,_moveSpeed,0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(_moveSpeed,0,0);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_moveSpeed,0,0);
        }

        if(Input.GetKey(KeyCode.S))
        {
             transform.position -= new Vector3(0,_moveSpeed,0);  
        }

     

        // // 적이 발견되었는지 여부 업데이트
        // if (enemy != null)
        // {
        //     isEnemyDetected = true;
        // }
        // else
        // {
        //     isEnemyDetected = false;
        // }

        // 
        coolTime -= Time.deltaTime;
        
        if(coolTime <= 0)
        {
            findEnemy();
            coolTime = 1f;
        }

    }
}
