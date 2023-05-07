using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float _moveSpeed = 1000f;

    public float _hp = 100f;

    public float coolTime = 1f;

    public Transform firePoint;

    public bool isEnemyDetected = false;

    public float detectionRadius = 1f; 

    private List<Enemy> enemies;

    public GameObject bulletPrefab;
    public float turnSpeed = 180f;

    //
    // List<GameObject> snakeBody = new List<GameObject>();
    // List<GameObject> bodyParts = new List<GameObject>();

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

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>()); 

        // createBodyParts();
    }

    // void SnakeMovement()
    // {
    //     snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * _moveSpeed * Time.deltaTime;

    //     if(Input.GetAxis("Horizontal") != 0)
    //         snakeBody[0].transform.Rotate(new Vector3(0,0,-turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
    // }

    void attack()
    {
        
    }

    // void createBodyParts()
    // { 
        

    //     //맨뒤의 몸체 
    //     BodyManger bodyM = snakeBody[snakeBody.Count - 1].GetComponent<BodyManger>();

    //     if(countUp == 0)
    //     {
    //         bodyM.ClearBodyList(); 
    //     }

    //     countUp += Time.deltaTime;

    //     if(countUp >= 0.2f)
    //     {
    //         GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);

    //         if(!temp.GetComponent<BodyManger>())
    //             temp.AddComponent<BodyManger>(); 

    //         if(!temp.GetComponent<Rigidbody2D>())
    //         {
    //             temp.AddComponent<Rigidbody2D>();
    //             temp.GetComponent<Rigidbody2D>().gravityScale = 0;
    //         }

    //         snakeBody.Add(temp);
    //         bodyParts.RemoveAt(0);
    //         temp.GetComponent<BodyManger>().ClearBodyList();
    //         countUp = 0;
    //     }

    // }



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
