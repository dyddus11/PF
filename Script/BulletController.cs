using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   private Vector3 direction; 
   private float speed; 
   private Vector3 enemyPosition;

   private int count = 0;

   private void Update() 
   {
        transform.position += this.direction * speed * Time.deltaTime;
   }

    public void SetDirectionAndSpeed(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }

    public void SetEnemyPosition(Vector3 position)
    {
        enemyPosition = position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameObject otherGameObject= other.gameObject;
            Enemy enmey = otherGameObject.GetComponent<Enemy>();
            enmey.Hp = 0; 
            count++; 

            Vector2 direction = (other.transform.position - transform.position).normalized; // 충돌한 객체와 총알의 위치 벡터 차를 구하고 정규화하여 방향 벡터 계산
            this.direction = direction;
            transform.Translate(direction * speed * Time.deltaTime); // 총알 이동 방향을 변경하여 적 방향으로 날아가도록 함

            if(count >= 10)
                Destroy(gameObject);
            // Lighting();
            // Destroy(gameObject);
        } 
    }

    private void Lighting()
    {
        Vector3 hitPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(hitPos, 2f, LayerMask.GetMask("Enemy")); 

        foreach (var collider in colliders)
        {
            Vector3 enemyPos = collider.transform.position;

            Vector3 diff = enemyPos - hitPos;
            diff.y = 0f; 

            if(diff != Vector3.zero)
            {
                transform.forward = diff.normalized;
                break;
            }
        }
        // HashUtilities = true;

    }

    void OnCollisionEnter(Collision other) 
    {

    }
}
