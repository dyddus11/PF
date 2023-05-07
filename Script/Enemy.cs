using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float _distance;
    public GameObject Player; 

    public float ATK = 1f;
    public float coolTime = 1f;

    public float Hp  = 1f; 

    public float exp = 1f;

    public bool sturn = false;

    public float sturnTime = 2f;

    private Material playerMaterial; 
    private Color originalColor;

    private Color hitColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
        playerMaterial = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material;
        originalColor = playerMaterial.color;
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
       Vector3 KnockbackDir = Player.transform.position - transform.position;  

       float KnockbackMagnitude = KnockbackDir.magnitude;
       KnockbackDir.y = 0f;
       KnockbackDir = KnockbackDir.normalized * 1f;

       Player.GetComponent<Rigidbody2D>().AddForce(KnockbackDir, ForceMode2D.Impulse);

       StartCoroutine(ChangeColorRoutine());
    }

    private IEnumerator ChangeColorRoutine()
    {
        playerMaterial.color = hitColor; 
        yield return new WaitForSeconds(0.2f);

        playerMaterial.color = originalColor;
        yield return new WaitForSeconds(0.2f);

        playerMaterial.color = hitColor;
        yield return new WaitForSeconds(0.2f);

        playerMaterial.color = originalColor;
    }


    void takeDamage(float damage)
    {
        Hp -= damage;
    }

    void dead()
    {
        Destroy(gameObject);
    }

    float giveExp()
    {
        return exp;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(_distance <= 1.0f)
        {   
            coolTime -= Time.deltaTime;

            if(coolTime <= 0)
            {
                attack();    
                coolTime = 1f;
            }
        }

        if(sturn)
        {
            sturnTime -= Time.deltaTime; 


            if(sturnTime<=0)
            {
                sturnTime = 3f;
                sturn = false;
            }

        } else {
            moving();
        }

        if(Hp <= 0)
        {
            dead();
            ExpManger expManger = FindObjectOfType<ExpManger>();

            if(expManger != null)
            {
                expManger.GainExp(exp);
            }
        }
    }
}
