using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPVIewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHp playerHP;
    private Slider sliderHP;
    // Start is called before the first frame update
    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }
    private void Update()
    {
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
