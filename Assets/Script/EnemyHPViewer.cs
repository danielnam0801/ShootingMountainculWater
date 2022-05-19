using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHp enemyHP;
    private Slider hpSlider;

    public void Setup(EnemyHp enemyHP)
    {
        this.enemyHP = enemyHP;
        hpSlider = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        hpSlider.value = enemyHP.currentHP / enemyHP.maxHP;
    }
}
