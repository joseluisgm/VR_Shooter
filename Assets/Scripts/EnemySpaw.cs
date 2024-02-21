
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpaw : MonoBehaviour
{
    [SerializeField] private int enemyNumber;
    [SerializeField] private int Minuts;
    [SerializeField] private int enemyIncement;
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private List<Transform> SpawnPoints;
    
    public static EnemySpaw Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
    public void StartWave() => StartCoroutine(SpawnEnemy());


    IEnumerator SpawnEnemy()
    {     
        yield return new WaitForSeconds(Minuts * 60);      
        //loop to instance new enemys
        int spawnPosition = Random.Range(0, SpawnPoints.Count);
        for (int i = 0; i < enemyNumber; i++)
        {
            Instantiate(enemyObject, SpawnPoints[spawnPosition].transform.position, Quaternion.identity);
        }
        enemyNumber += enemyIncement;        
        StartCoroutine(SpawnEnemy());
    }







}

