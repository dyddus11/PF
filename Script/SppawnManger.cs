using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SppawnManger : MonoBehaviour
{
    public GameObject Enemy; 
    public float spawnRange = 10.0f;
    public float spawnDistance = 10.0f;
    public Transform[] _spawnPoint; 

    public void Spawn()
    {
        // Camera mainCamera = Camera.main;

        // Vector3 cameraPosition = mainCamera.transform.position; 
        // Vector3 cameraForward = mainCamera.transform.forward;

        // Vector3 spawnPosition = cameraPosition + cameraForward * spawnDistance;
        // Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // int index = Random.Range(0, _spawnPoint.Length); 
        // Transform spawnPoint = _spawnPoint[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
