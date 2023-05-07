using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject PlayerPrefab; 
    public GameObject AxePrefab;
    public float speed = 1.0f; 
    public float radius = 2.0f;
    public float angle = 0.0f;

    public float damage = 1f;

    void Start()
    {
        PlayerPrefab = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        Vector3 pos = PlayerPrefab.transform.position + new Vector3(x,y,0);

        AxePrefab.transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameObject otherGameObject= other.gameObject;
            Enemy enmey = otherGameObject.GetComponent<Enemy>();
            enmey.Hp -=  damage;
        } 
    }
}
