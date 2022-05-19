using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : BulletMove
{
    private PlayerController player = null;
    Vector3 dir;
    
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    protected override void Start()
    {
        speed = 7;
        
    }

    private void OnEnable()
    {
        int randvalue = Random.Range(0,10);
        //시작 - 끝
        if (randvalue < 4)
        {
            dir = transform.position - player.transform.position;
            dir.Normalize();
            transform.Translate(Vector2.up * 7 * Time.deltaTime);
            float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90f);
            //transform.up = dir;
            //Debug.Log(rotation);
            //Debug.Log(transform.eulerAngles);

            //StartCoroutine(Test());
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            

        }
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Square"))
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update

}
