using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        inGame,
        gameOver
    }

    public GameStates currentGameState;
    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeText;
    public Button restartBtn;
    public GameObject titleScreen;

    private float spawnRate = 1.5f;
    private int _totalLifes = 3;

    private int _score;
    private int Score {
        get
        {
            return _score;
        }
        set
        {
            _score = Mathf.Clamp(value, 0, 9999);
        }
    }
    void Start()
    {
        ShowMaxScore();
    }

    IEnumerator SpawnTarget()
    {
        while (currentGameState == GameStates.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    private void PrintScore()
    {
        scoreText.text = "Score: \n" + Score;
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        PrintScore();
    }

    public void UpdateLife(int damage)
    {
        _totalLifes -= damage;
        ShowLife();
        if (_totalLifes == 0) {
            GameOver();
        }
    }

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("Max_SCORE", 0);
        scoreText.text = "Max Score: \n" + maxScore;
    }

    public void ShowLife()
    {
        lifeText.text = "LIFE: " + _totalLifes;
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        currentGameState = GameStates.inGame;
        StartCoroutine(SpawnTarget());
        Score = 0;
        PrintScore();
        titleScreen.gameObject.SetActive(false);
        ShowLife();

    }

    public void GameOver()
    {
        currentGameState = GameStates.gameOver;
        CheckIfIsMaxScore();
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void CheckIfIsMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("Max_SCORE", 0);
        if (Score > maxScore)
        {
            PlayerPrefs.SetInt("MAX_SCORE", maxScore);
        }
    }
}
