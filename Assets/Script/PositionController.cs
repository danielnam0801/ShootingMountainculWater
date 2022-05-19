using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float scrollRange = 9.9f;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.down;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime ;

        if(transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}