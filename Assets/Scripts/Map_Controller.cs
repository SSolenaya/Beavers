using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Controller : MonoBehaviour
{
    public int SpotEnemy; //кол-во появляющихся монстров
    public GameObject EnemyPrefab;//префаб нашего бобра
    public float EnemyInterval;//интервал появления
    public Transform spawnPoint;
    public float startTime;
    int enemyCount = 0;//изначальное кол-во монстров на карте

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startTime, EnemyInterval); //через какой промежуток времени начнут появляться монстры   
    }

    void Update()
    {
        if (enemyCount == SpotEnemy)
        {
            CancelInvoke("SpawnEnemy");//останавливает появление монстров, если их кол-во равно кол-ву мест появления
        }
    }

    void SpawnEnemy()
    {
        enemyCount++;//суммирует монстров на карте
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
    }
}