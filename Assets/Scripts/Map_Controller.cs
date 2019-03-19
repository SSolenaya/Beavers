using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Controller: MonoBehaviour {
    public int SpotEnemy; //кол-во появляющихся монстров
    public GameObject EnemyPrefab;//префаб нашего бобра
    public float EnemyInterval;//интервал появления
    public Transform spawnPoint;
    public float startTime;
    int enemyCount = 0;//изначальное кол-во монстров на карте

    //salt2 контроллер должен быть синглтон. Тут должен быть массив public List<Transform> listCell - массив мест куда спавнить бобров.

    void Start () {
        InvokeRepeating("SpawnEnemy", startTime, EnemyInterval); //через какой промежуток времени начнут появляться монстры   //salt1 не использовать. Лучше коротину или таймер в Update
        
    }

    void Update () {
        if(enemyCount == SpotEnemy) {
            CancelInvoke("SpawnEnemy");//останавливает появление монстров, если их кол-во равно кол-ву мест появления
        }
    }

    void SpawnEnemy () {
        enemyCount++;//суммирует монстров на карте
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
    }
}