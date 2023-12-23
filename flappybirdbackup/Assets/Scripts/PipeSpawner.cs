using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject shieldPowerUpPrefab;
    [SerializeField] private float spawnDelay = 20f;
    [SerializeField] private float BasePipeSpeed = 3f;
    [SerializeField] private float height = 0.4f;
    
    public GameObject dayBackground;
    public GameObject nightBackground;

    private float timer;
    private float currentPipeSpeed;
    private bool isPowerUpActive = false;

    private void Start()
    {
        currentPipeSpeed = BasePipeSpeed;
        PipeSpawn();
    }

    private void Update()
    {
        if (!isPowerUpActive && timer > spawnDelay)
        {
            PipeSpawn();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void SetPowerUpActive(bool isActive)
    {
        isPowerUpActive = isActive;
    }

    private void PipeSpawn()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-height, height));

        GameObject pipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        if (Random.Range(0f, 1f) < 0.05f) // %5 olasýlýk
        {
            GameObject shieldPowerUp = Instantiate(shieldPowerUpPrefab, spawnPosition, Quaternion.identity);
            shieldPowerUp.transform.parent = pipe.transform;
        }

        // SpeedPowerUp Tamamlanmaadý Hatalý
        /*if (Random.Range(0f, 1f) < .05f) 
        {
            GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
            powerUp.transform.parent = pipe.transform;
        }*/

        Destroy(pipe, 7f);
    }

}
