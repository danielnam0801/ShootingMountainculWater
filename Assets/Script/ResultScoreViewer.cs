using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    private TextMeshProUGUI textResultScore;
    private TextMeshProUGUI textBestScore;
    //private TextMeshProUGUI textBestScore;
    // Start is called before the first frame update
    private void Awake()
    {
        textResultScore = GetComponent<TextMeshProUGUI>();
        int score = PlayerPrefs.GetInt("Score");
        textResultScore.text = "Score " + score;
        textBestScore = GetComponent<TextMeshProUGUI>();
        int bestScore = PlayerPrefs.GetInt("Best Score", 0);
        textBestScore.text = "Best Score : " + bestScore;


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
