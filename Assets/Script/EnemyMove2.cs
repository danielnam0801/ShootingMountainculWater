using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    //private PlayerController player = null;
    [SerializeField]
    private float moveSpeed = 1.0f;
    Vector3 dir;

    //private void Awake()
    //{
    //    player = FindObjectOfType<PlayerController>();
    //}
    //protected override void Start()
    //{
    //    speed = 5;
    //}

    private void Awake()
    {
        transform.rotation =  Quaternion.Euler(0, 0, 180);
    }
    private void Update()
    {
        Move();

    }
    private void Move()
    {
         dir = Vector3.down;
        transform.position += dir * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Square"))
        {
            Destroy(gameObject);
        }
    }
}
