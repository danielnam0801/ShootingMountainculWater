using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text CurrentScoreText;
    private int currentScore;
    public Text bestScoreText;
    private int bestScore;

    public void SetScore(int value)
    {
        currentScore = value;
        CurrentScoreText.text = "Score : " + currentScore;
        PlayerPrefs.SetInt("Score", currentScore);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreText.text = "BestScore : " + bestScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }
    public int GetScore()
    {
        return currentScore;
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreText.text = "Best Score : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
