using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI restartText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private float time;
    private float timeCounter;
    [SerializeField]
    private int lives;

    private bool isRestarting;

    public static GameManager Instance { get; private set; }
    public float RestTime { get => timeCounter; set => timeCounter = value; }
    public bool IsRestarting { get => isRestarting; set => isRestarting = value; }
    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        timeCounter = time;

        livesText.text = "Lives: " + lives;
    }

    private void Update()
    {
        if (!isRestarting)
            timeCounter -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(timeCounter).ToString("0000");
            if (timeCounter <= 0)
                StartCoroutine(GameOver());
    }

    private void Start() => EnemySpawn.Instance.StartWave();

    public void UpdateScore() => scoreText.text = "Score: " + score.ToString("00000");

    public void Restart()
    {
        if (isRestarting)
            for (int i = 0; i < EnemySpawn.Instance.SpawnedEnemies.Count; i++)
            {
                var enemy = EnemySpawn.Instance.SpawnedEnemies[i];

                EnemySpawn.Instance.SpawnedEnemies.RemoveAt(i);

                Destroy(enemy);
            }

            timeCounter = time;

        score = 0;

        UpdateScore();

        livesText.text = "Lives: " + lives;
    }

    private IEnumerator GameOver()
    {
        lives--;

        if (lives <= 0)
            Application.Quit();

        isRestarting = true;

        gameOverPanel.SetActive(true);

        Restart();

        for (int i = 3; i >= 0; i--)
        {
            restartText.text = "Restart in " + i + " seconds";

            yield return new WaitForSeconds(1);
        }

        gameOverPanel.SetActive(false);

        isRestarting = false;
    }
}
