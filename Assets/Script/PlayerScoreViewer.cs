using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;
    public TextMeshProUGUI textScore;
    private int currentScore;
    private int bestScore;
    public TextMeshProUGUI BestScore;
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        BestScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = PlayerPrefs.GetInt("Score", 0);
        textScore.text = "Score " +PlayerController.Score;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScore.text = "Best Score "+PlayerController.BestScore;
    }
}
