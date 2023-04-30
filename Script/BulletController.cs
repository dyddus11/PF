using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   private Vector3 direction; 
   private float speed; 

   private Vector3 enemyPosition;

   private void Update() 
   {
        transform.position += direction * speed * Time.deltaTime;
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

            Destroy(gameObject);
        } 
    }

    void OnCollisionEnter(Collision other) 
    {

    }
}
