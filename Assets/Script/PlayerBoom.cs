using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    //[SerializeField]
    //private AudioClip boomAudio;
    private float boomDelay = 0.5f;
    private Animator animator;
    [SerializeField]
    private int damage = 50;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDelay;
            transform.position = Vector3.Lerp(startPosition,endPosition, curve.Evaluate(percent));
            yield return null;
        }

        animator.SetTrigger("onBoom");
    }
    
    public void OnBoom()
    { 
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");  
        for(int i = 0 ; i<enemys.Length; ++i)
        {
            enemys[i].GetComponent<Enemy>().OnDie();    
        }
        Destroy(gameObject);
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if(boss != null)
        {
            boss.GetComponent<BossHP>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    
 

}
