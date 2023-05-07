using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SppawnManger : MonoBehaviour
{
    public float spawnTime = 0.5f; 

    public Transform[] spawnPoints; 
    public float spawnRadius = 10.0f;
     private Vector2 screenBounds;

    private Camera mainCamera; 

    public GameObject[] enemies; 

    public GameObject enemyPrefab;

    public void Spawn()
    {
        // Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
        // Vector3 randomScreenPoint = mainCamera.ViewportToWorldPoint(new Vector3(randomPoint.x, randomPoint.y, 10f));

        // // GameObject randomEnemy = enemies[Random.Range(0, )]

        // Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; 
        // Instantiate(EnemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

           // 랜덤한 위치 계산
        Vector2 spawnPosition = new Vector2(Random.Range(screenBounds.x, screenBounds.x + 2f * screenBounds.magnitude),
                                            Random.Range(screenBounds.y, screenBounds.y + 2f * screenBounds.magnitude));

        for(int i =0; i<5; i++)
        {
                    // 적 생성
            Instantiate(enemyPrefab, spawnPosition += Vector2.left, Quaternion.identity);
        }
    }

    void Start()
    {
        // mainCamera = Camera.main; 

        // spawnPoints = new Transform[transform.childCount];

        // for(int i =0; i< transform.childCount; i++)
        // {
        //     spawnPoints[i] = transform.GetChild(i);
        // }

        // InvokeRepeating("Spawn",spawnTime, spawnTime);

         mainCamera = Camera.main;

        // 카메라의 크기와 위치를 가져와서 스크린 바운드 계산
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        screenBounds = new Vector2(mainCamera.transform.position.x - cameraWidth / 2f,
                                   mainCamera.transform.position.y - cameraHeight / 2f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime; 

        if(spawnTime <= 0)
        {
            Spawn();
            spawnTime = 3.0f; 
        }

    }
}
