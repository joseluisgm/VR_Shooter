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

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void UpdateScore()
    {

        scoreText.text = score.ToString("00000");
    }
}
