using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int scorePoint = 100;   
    private PlayerController playerController;
    PlayerHp HP;
    
    private void Start()
    {
        HP = FindObjectOfType<PlayerHp>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    
    public void OnDie()
    {
        ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        sm.SetScore(sm.GetScore() + scorePoint);
        Destroy(gameObject);
    }
}
