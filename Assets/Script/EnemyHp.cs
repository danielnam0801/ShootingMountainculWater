using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField]
    public float maxHP = 4;
    public float currentHP;
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StartCoroutine(HitColorAnimation());
        //StopCoroutine("HitColorAnimation");

        if(currentHP <= 0)
        {
            enemy.OnDie();
            
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.green; 
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Square"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
