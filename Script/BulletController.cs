using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   private Vector3 direction; 
   private float speed; 
   
   public bool stop = false;
   private Vector3 enemyPosition;

   private int count = 0;

   private void Update() 
   {
        if(stop)
            return;

        transform.position += this.direction * speed * Time.deltaTime;
   }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetEnemyPosition(Vector3 position)
    {
        enemyPosition = position;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         GameObject otherGameObject= other.gameObject;
    //         Enemy enmey = otherGameObject.GetComponent<Enemy>();
    //         enmey.Hp -=  0.5f;

    //         // count++; 
    //         // Vector2 direction = (other.transform.position - transform.position).normalized; // 충돌한 객체와 총알의 위치 벡터 차를 구하고 정규화하여 방향 벡터 계산
    //         // this.direction = direction;
    //         // transform.Translate(direction * speed * Time.deltaTime); // 총알 이동 방향을 변경하여 적 방향으로 날아가도록 함

    //         // if(count >= 10)
    //         //     Destroy(gameObject);
    //         // Lighting();
    //         // Destroy(gameObject);
    //     } 
    // }

}
