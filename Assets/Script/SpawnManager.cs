using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    public float enemyDuration;
    //[SerializeField]
    //private GameObject enemyHpSliderPrefab;
    //[SerializeField]
    //private Transform canvastransform;
    [SerializeField]
    private GameObject enemyprefab;
    private EnemyManager enemyManager;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        // Quaternion.identity : 각도를 0 0 0 으로 바꾸어 준다
        //GameObject g = Instantiate(player, spawnPos, Quaternion.identity);
        //rb = g.GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Move();
    //    SpawnBullet();
    //}

    private void Move()
    {

        //가로기준 왼쪽 : -1  안누르면 : 0  오른쪽 :1
        float hori = Input.GetAxisRaw("Horizontal");
        //세로기준 위 : 1 안누르면 : 0 밑 : -1
        float verti = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hori, verti).normalized * 10f;
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            GameObject enemyclone = Instantiate(enemyprefab, position, Quaternion.identity);
            //GameObject enemyclone = Instantiate(enemyprefab);
            //enemyclone.transform.position = position;
            yield return new WaitForSeconds(enemyDuration); 
            if(enemyManager.GetMonster() == true)
            {
                 break;
            }

        }


    }
    //private void SpawnEnemyHpSlider(GameObject enemy)
    //{
    //    GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
    //    sliderClone.transform.SetParent(canvastransform);
    //    sliderClone.transform.localScale = Vector3.one;
    //}
}