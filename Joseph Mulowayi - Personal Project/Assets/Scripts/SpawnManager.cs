using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    private PlayerController pcScript;
    private float spawnRange = 22.0f;
    private float startDelay = 2.0f;
    private float repeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPowerup", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerup() 
    {
        if (pcScript.gameOver == false)
        {
            Instantiate(powerupPrefab, GenarateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    private Vector3 GenarateSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 3, spawnPosZ);

        return randomPos;
    }
}
