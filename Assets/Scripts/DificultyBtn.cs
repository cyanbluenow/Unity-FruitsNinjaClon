using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyBtn : MonoBehaviour
{
    private Button _btn;
    private GameManager gameManager;
    [Range(1,4)] public int difficultyBtn;

    void Start()
    {
        _btn = GetComponent<Button>();
        gameManager = FindObjectOfType<GameManager>();
        _btn.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficultyBtn);
    }
}
