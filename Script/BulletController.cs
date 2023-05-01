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
            Lighting();
            // Destroy(gameObject);
        } 
    }

    private void Lighting()
    {
        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float detectionRadius = 10f; 

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Enmey")); 

        foreach(Collider collider in colliders)
        {
            GameObject enemy = collider.gameObject;
            Debug.Log("enemy: " + enemy.transform.position);
        }

    }

    void OnCollisionEnter(Collision other) 
    {

    }
}
