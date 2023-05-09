using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Bullet
{
    new float speed = 1f;
    // Start is called before the first frame update
    float explodeScale = 1.1f;
    public float fadeDuration = 1.0f;

    public new float damage = 1f;

    float explodeTimer = 3f;

    bool exploded = false; 
    void Start()
    {
        setSpeed(speed);
    }

    void Explode()
    {
        transform.localScale = Vector3.one * explodeScale;
    }

    void AfterExplode()
    {

        if(explodeScale<=0)
        {
            Destroy(gameObject);
            return;
        }

        explodeScale -= Time.deltaTime;
        transform.localScale = Vector3.one * explodeScale;
    }

    void Update()
    {
        if(explodeTimer <= 0f)
        {
            Destroy(gameObject);
        }

        if(exploded)
        {
            explodeTimer -= Time.deltaTime;
            AfterExplode();    
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameObject otherGameObject= other.gameObject;
            Enemy enmey = otherGameObject.GetComponent<Enemy>();
            enmey.takeDamage(damage);

            if(!exploded)
            {
                this.Explode();
                this.setStop();
                exploded = true;
            }
        } 
    }
}
