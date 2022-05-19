using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 3;
    private float currentHP;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
            TakeDamage(1);
        else if(collision.CompareTag("Enemy1"))
            TakeDamage(2);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if(currentHP<=0)
        {
            playerController.OnDie();

        }
    }    
}
