using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType { Stage = 0, Boss}
public class BGMController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] bgmClips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBGM(BGMType index)
    {
        audioSource.Stop();
        audioSource.clip = bgmClips[(int)index];
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
