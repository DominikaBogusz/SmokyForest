using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private static GameMaster instance;
    public static GameMaster Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameMaster>();
            }
            return instance;
        }
    }

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "SCORE: " + score;
        }
    }
    public int HighScore { get; set; }

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject gameOverScreen;

    void Start()
    {
        Score = 0;
    }

    public void EndGame()
    {
        SaveScore();
        ShowGameOverScreen();
    }

    private void SaveScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < Instance.Score)
        {
            PlayerPrefs.SetInt("HighScore", Instance.Score);
        }
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Score", Instance.Score);
    }

    private void ShowGameOverScreen()
    {
        Time.timeScale = 0.0f;

        scoreText.fontSize += 2;
        scoreText.rectTransform.pivot = new Vector2(0.5f, 1f);
        scoreText.rectTransform.anchorMin = new Vector2(0.5f, 1f);
        scoreText.rectTransform.anchorMax = new Vector2(0.5f, 1f);

        gameOverScreen.SetActive(true);
    }
}
