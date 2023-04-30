using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float _moveSpeed = 1000f;

    public float _hp = 100f;

    // public GameObject Bullet;
    public float coolTime = 1f;

    public Transform firePoint;

    public bool isEnemyDetected = false;

    public float detectionRadius = 100f; 

    public Enemy enemy;
    private List<Enemy> enemies;

    public GameObject bulletPrefab;

    public void findEnemy()
    {
        Enemy nearestEnemy = null; 
        float nearestDistance = Mathf.Infinity;

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

            bulletController.SetDirectionAndSpeed(direction,10f);

            bulletController.SetEnemyPosition(nearestEnemy.GetPos());
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>()); 
    }

    void attack()
    {
        
    }


    // Update is called once per frame
    void Update()
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

     

        // 적이 발견되었는지 여부 업데이트
        if (enemy != null)
        {
            isEnemyDetected = true;
        }
        else
        {
            isEnemyDetected = false;
        }

        // 
        coolTime -= Time.deltaTime;
        
        if(coolTime <= 0)
        {
            findEnemy();
            coolTime = 1f;
        }

    }
}
