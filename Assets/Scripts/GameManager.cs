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
    private GameObject gameOverPanel;
    [SerializeField]
    private float time;

    public static GameManager Instance { get; private set; }
    public float RestTime { get => time; set => time = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.RoundToInt(time).ToString("0000");
        if (time <= 0)
            GameOver();
    }

    private void Start() => EnemySpawn.Instance.StartWave();

    public void UpdateScore() => scoreText.text = "Score: " + score.ToString("00000");

    public void Restart()
    {
        Debug.Log("Hola;");
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
