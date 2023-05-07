using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttack : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        // GameObject IceAttack = new GameObject("IceAttack"); 
        // IceAttack.AddComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameObject otherGameObject= other.gameObject;
            Enemy enmey = otherGameObject.GetComponent<Enemy>();
            // Rigidbody enemyRigidBody = otherGameObject.GetComponent<Rigidbody>();
            // enemyRigidBody.velocity = Vector3.zero;
            // enemyRigidBody.angularVelocity = Vector3.zero; //회전 속도 0
            enmey.sturn = true;
        } 
    }
}
