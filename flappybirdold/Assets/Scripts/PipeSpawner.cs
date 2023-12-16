using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnDelay = 20f;
    [SerializeField] private float height = .4f;

    private float timer;

    private void Start()
    {
        PipeSpawn();
    }
    private void Update()
    {
        if (timer > spawnDelay)
        {
            PipeSpawn();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void PipeSpawn()
    {
        Vector3 spawnPosition=transform.position + new Vector3(0, Random.Range(-height, height));

        GameObject pipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        
        Destroy(pipe, 7f);
    }
}
