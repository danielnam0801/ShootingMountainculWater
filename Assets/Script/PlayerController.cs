using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keycodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.X;
    private Weapon weapon;
    [SerializeField]
    private GameObject maxPos = null;
    [SerializeField]
    private GameObject minPos = null;

    private int score;
    private int bestScore = 0;
    public int Score
    {
        set => score = Mathf.Max(0,value);
        get => score;
    }
    public int BestScore
    {
        set => Mathf.Max(0, value);
        get => bestScore;
    }

    public float speed = 10f;

    private Rigidbody2D rb = null;

    public GameObject bullet = null;

    public float shootDuration = 0.5f;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();

        //StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(keycodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keycodeAttack))
        {
            weapon.StopFiring();
        }
        if (Input.GetKeyDown(keyCodeBoom))
        {
            Debug.Log("´­¸²");
            weapon.StartBoom();
        }
    }

    private void Move()
    {

        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hori, verti).normalized * speed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minPos.transform.position.x, maxPos.transform.position.x), Mathf.Clamp(transform.position.y, minPos.transform.position.y, maxPos.transform.position.y));
    }

    public void OnDie()
    {
        Debug.Log(score);
        Debug.Log(bestScore);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("BestScore", bestScore);
        SceneManager.LoadScene(nextSceneName);
    }

    /*private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDuration);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }*/


}   