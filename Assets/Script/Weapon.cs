using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField]
    private GameObject boomPrefab;
    private int boomCount = 3;
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    public void StartBoom()
    {
        
        if(boomCount > 0)
        {
            boomCount--;
            Instantiate(boomPrefab, transform.position,Quaternion.identity);
        }
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(attackRate);
        }
    }
  
}
