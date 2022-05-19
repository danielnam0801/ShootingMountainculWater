using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the 
    public Text CurrentScoreText;
    private int currentScore;
    public Text BestScoreText;
    private int bestScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("Score");
        CurrentScoreText.text = "Result Score : " + currentScore;
        bestScore = PlayerPrefs.GetInt("Best Score");
        BestScoreText.text = "Best Score : " + bestScore;
    }

}