using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private int damage = 1;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = 20;
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime/*, Space.Self*/);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Square2"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy")){
            other.GetComponent<EnemyHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Boss"))
        {
            Debug.Log("1111111111");
            other.GetComponent<BossHP>().TakeDamage(damage);
            Destroy (gameObject);
        }
    }
}
