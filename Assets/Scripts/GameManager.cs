using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI scoreText;
    private float spawnRate = 1.0f;

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

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        Score = 0;
        PrintScore();
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
