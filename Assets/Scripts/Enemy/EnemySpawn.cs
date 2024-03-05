using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] 
    private int enemyNumber;
    [SerializeField] 
    private int minutes;
    [SerializeField] 
    private int enemyIncrement;
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField] 
    private List<Transform> spawnPoints;
    [SerializeField] 
    private List<Transform> forwardPoints;

    private List<GameObject> spawnedEnemies = new(); 
    
    public static EnemySpawn Instance { get; private set; }
    public List<Transform> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
    public List<Transform> ForwardPoints { get => forwardPoints; set => forwardPoints = value; }
    public List<GameObject> SpawnedEnemies { get => spawnedEnemies; set => spawnedEnemies = value; }

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
        yield return new WaitUntil(() => spawnedEnemies.Count == 0);

        yield return new WaitUntil(() => !GameManager.Instance.IsRestarting);

        for (int i = 0; i < enemyNumber; i++)
            spawnedEnemies.Add(Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, Quaternion.identity));

        enemyNumber += enemyIncrement;        
        StartCoroutine(SpawnEnemy());
    }
}

