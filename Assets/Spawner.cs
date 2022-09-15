using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn, HP;
    [SerializeField] private float nextWaveTime;
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Transform[] Points;

    private float timer;
    private float waveTimer;
    private Enemy enemy;
    void Start()
    {
        timer = timeToSpawn;
        waveTimer = 0;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            if(waveTimer >= nextWaveTime)
                enemy = Instantiate(enemyPrefabs[1], transform.position, Quaternion.identity);
            else
                enemy = Instantiate(enemyPrefabs[0], transform.position, Quaternion.identity);
            enemy.Points = Points;
            enemy.HP = HP;

            

            timer = timeToSpawn;
            waveTimer++;
            

        }
    }
}
